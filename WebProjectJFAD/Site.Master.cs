using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace WebProjectJFAD
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public static string Conn_String = WebConfigurationManager.ConnectionStrings["ProductDb"].ConnectionString;
        public List<ProductCategory> Categories = new List<ProductCategory>();
        public delegate void SignInDelegate(string name);
        public event SignInDelegate SignInEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SignedInUser.Text = null;
                NumberInCart();
                //Check if a Customer is signed in
                if (Request.Cookies[FormsAuthentication.FormsCookieName] == null)
                {
                    SignedInUser.Visible = false;
                    hlSignIn.Visible = true;
                    hlRegister.Visible = true;
                }
                else
                {
                    // if someone is signed in it takes the information from the Auth Cookie and uses it to retrieve the customer with that user name.
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);
                    Customer c = ReturnCustomer(ticket.Name);
                    //Displays their first and last name in the navigation
                    SignedInUser.Text = string.Format("Hello, {0} <span class='caret'></span>", c.FirstName + " " + c.Lastname);
                    SignedInUser.Visible = true;
                    hlSignIn.Visible = false;
                    hlRegister.Visible = false;
                }
                //if remember cookie exists fill in information in sign in form
                if (Request.Cookies["Remember"] != null)
                {
                    chkRemember.Checked = true;
                    txtUsername.Text = Request.Cookies["Remember"]["Username"];
                }

            }

            using (ProductDb db = new ProductDb())
            {
                Categories = db.ProductCategorys.Include("SubCategories").ToList();

                foreach (ProductCategory pc in Categories)
                {
                    //Dynamically create a link for each Product Category in the database
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes["class"] = "dropdown";
                    HyperLink link = new HyperLink();
                    //link.NavigateUrl = string.Format("~/Products.aspx?CategoryID={0}", pc.CatergoryID);
                    link.NavigateUrl = "#";
                    link.ID = "Category" + pc.CatergoryID.ToString();
                    link.Text = pc.CategoryType + " <span class='caret'></span>";
                    link.CssClass = "dropdown-toggle";
                    link.Attributes["role"] = "button";
                    link.Attributes["data-toggle"] = "dropdown";
                    link.Attributes["aria-expanded"] = "false";
                    HtmlGenericControl span = new HtmlGenericControl("span");
                    span.Attributes["class"] = "caret";
                    li.Controls.Add(link);
                    HtmlGenericControl ul = new HtmlGenericControl("ul");
                    ul.Attributes["class"] = "dropdown-menu";
                    ul.Attributes["role"] = "menu";
                    li.Controls.Add(ul);
                    //For each Product Category create a dropdown with links for each Sub Category in the database
                    foreach (ProductSubCategory psc in pc.SubCategories)
                    {
                        HtmlGenericControl li2 = new HtmlGenericControl("li");
                        HyperLink Sublink = new HyperLink();
                        Sublink.NavigateUrl = string.Format("~/Products.aspx?SubCategoryID={0}", psc.SubCatergoryID);
                        Sublink.Text = psc.SubCategoryType;
                        Sublink.ID = "SubCategory" + psc.SubCatergoryID.ToString();
                        li2.Controls.Add(Sublink);
                        ul.Controls.Add(li2);
                    }
                    NavList.Controls.Add(li);
                }

            }
        }

        public void NumberInCart()
        {
            List<CartItem> newCartList = new List<CartItem>();
            if ((List<CartItem>)Session["listCartItems"] != null)
                newCartList = (List<CartItem>)Session["listCartItems"];

            int noOfItems = 0;
            foreach (var item in newCartList)
            {
                noOfItems += item.Quantity;
            }
            if (noOfItems > 0)
            {
                hlCart.Text = String.Format("<span class='glyphicon glyphicon-shopping-cart'></span> Cart ({0})", noOfItems);
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Hash password the user has filled in
                string Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "MD5");
                bool signedin = false;
                int customerid;

                signedin = CheckSignIn(Password, out customerid);
                HttpCookie SigninError = new HttpCookie("Error");
                if (signedin == true)
                {
                    //set the error cookie to expire
                    SigninError.Expires = DateTime.Now.AddDays(-1);
                    RememberCookie(chkRemember, txtUsername);
                    Delegate(customerid);
                    Response.Cookies.Add(SigninError);
                    //Response.Redirect(Request.Url.ToString());
                    //Response.Redirect("Index.aspx");
                }
                else
                {
                    //sort the error in the error cookie
                    SigninError["ErrorMessage"] = "Your Username/Password are incorrect, Please try Again";
                    SigninError.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(SigninError);
                    Response.Redirect("SignIn.aspx");
                }

            }
        }

        public bool CheckSignIn(string Password, out int customerid)
        {
            bool signedin = false;
            customerid = -1;
            using (SqlConnection connection = new SqlConnection(Conn_String))
            {
                //call sproc that checks if user name and passowrd are valid, sproc takes in password and username, 
                //returns a value (0 if correct, 99 if wrong) and the id of the customer signing in in an output variable.
                try
                {
                    connection.Open();
                    SqlCommand Command = new SqlCommand("dbo.SignIn", connection);

                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@EUsername", txtUsername.Text);
                    Command.Parameters.AddWithValue("@EPassword", Password);
                    Command.Parameters.Add("@ECustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    SqlParameter parm = new SqlParameter("@Result", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    Command.Parameters.Add(parm);

                    Command.ExecuteNonQuery();
                    if ((Command.Parameters["@ECustomerID"].Value).ToString() != "")
                    {
                        customerid = Convert.ToInt32(Command.Parameters["@ECustomerID"].Value);
                    }

                    if ((int)parm.Value == 0)
                    {
                        signedin = true;
                    }
                    else
                        signedin = false;
                }
                catch (Exception ex)
                {
                    HttpCookie DatabaseError = new HttpCookie("Error");
                    DatabaseError["ErrorMessage"] = "There has been an unexpected error, Please Try again";
                    DatabaseError.Expires = DateTime.Now.AddDays(1);
                    Console.WriteLine("Connection Error = " + ex.Message);
                    Response.Cookies.Add(DatabaseError);
                    Response.Redirect("SignIn.aspx");
                }
            }
            return signedin;
        }

        //Deals with checking it remember me is checked 
        public void RememberCookie(CheckBox c, TextBox t)
        {
            //create the remember me cookie
            HttpCookie RememberMe = new HttpCookie("Remember");
            if (c.Checked)
            {
                //store the username in it
                RememberMe["Username"] = t.Text;
                RememberMe.Expires = DateTime.Now.AddYears(1);
            }
            else
            {
                RememberMe.Expires = DateTime.Now.AddDays(-1);
            }
            Response.Cookies.Add(RememberMe);
        }
        //Create a delegate and event
        public void Delegate(int customerid)
        {
            CustomerLogin cust;
            using (ProductDb db = new ProductDb())
            {
                //gets the customer using the id.
                cust = db.CustomerLogins.SingleOrDefault(c => c.Customer.CustomerId == customerid);
                if (cust != null)
                {
                    SignInDelegate sd = new SignInDelegate(CustomerAlert);
                    sd += UpdateNavbar;
                    sd += AuthCookie;
                    SignInEvent = sd;
                    SignInEvent(cust.UserName);
                }
            }
        }

        //Alert the customer has signed in
        public void CustomerAlert(string name)
        {
            Customer customer = ReturnCustomer(name);
            ScriptManager.RegisterStartupScript(this, GetType(), "Toastr", "Toastr('Welcome, " + customer.FirstName + " " + customer.Lastname + "', 'Success', 'Hello');", true);
        }
        //update navbar with the customer name
        public void UpdateNavbar(string name)
        {
            Customer customer = ReturnCustomer(name);
            SignedInUser.Text = string.Format("Hello, {0} <span class='caret'></span>", customer.FirstName + " " + customer.Lastname);
            hlSignIn.Visible = false;
            hlRegister.Visible = false;
            SignedInUser.Visible = true;
        }

        //returns a customer from the user name of the customer
        public Customer ReturnCustomer(string n)
        {
            using (ProductDb db = new ProductDb())
            {
                Customer customer = new Customer();
                CustomerLogin cl = db.CustomerLogins.Include(c => c.Customer).SingleOrDefault(c => c.UserName == n);
                if (cl != null)
                    customer = db.Customers.SingleOrDefault(cust => cust.CustomerId == cl.Customer.CustomerId);

                return customer;
            }
        }
        //creates the authentication cookie
        public void AuthCookie(string name)
        {
            FormsAuthentication.SetAuthCookie(name, true);
        }
        //signs out a customer and alerts the name of the customer signing out.
        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);
                Customer customer = ReturnCustomer(ticket.Name);
                ScriptManager.RegisterStartupScript(this, GetType(), "Toastr", "Toastr('Come Back Soon, " + customer.FirstName + " " + customer.Lastname + "', 'Error', 'Goodbye');", true);
                FormsAuthentication.SignOut();
            }
            hlSignIn.Visible = true;
            hlRegister.Visible = true;
            SignedInUser.Visible = false;
            SignedInUser.Text = string.Empty;
        }

    }//End Class
}//End Namespace