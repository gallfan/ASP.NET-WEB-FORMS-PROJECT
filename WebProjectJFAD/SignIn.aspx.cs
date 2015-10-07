using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProjectJFAD
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public static string Conn_String = WebConfigurationManager.ConnectionStrings["ProductDb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (!IsPostBack)
            {
                //Check if Remember me cookie exists and fill in details if it does
                if (Request.Cookies["Remember"] != null)
                {
                    chkRemember1.Checked = true;
                    txtUsername1.Text = Request.Cookies["Remember"]["Username"];
                }

                
            }
            //Check if a cookie carrying a error message exist and if it does show the error
            if (Request.Cookies["Error"] != null)
            {
                lblError.Text = Request.Cookies["Error"]["ErrorMessage"];
                HttpCookie SigninError = new HttpCookie("Error");
                SigninError.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(SigninError);
            }
                
        }//End Page Load

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //Hash password to check against password in database
                string Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword1.Text, "MD5");
                bool signedin = false;
                int customerid;
                
                //Master page
                Site m = (Site)this.Master;
                //using masterpage method to check the password
                signedin = m.CheckSignIn(Password, out customerid);
                HttpCookie SigninError = new HttpCookie("Error");
                if (signedin == true)
                {
                    SigninError.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(SigninError);
                    //using masterpage method to create remember cookie if needed
                    m.RememberCookie(chkRemember1, txtUsername1);
                    //using masterpage method to run the delegate if the password and username are correct
                    m.Delegate(customerid);
                    lblError.Text = "";

                    //Tried to redirect to page that was used to get to this page but didn't work
                    //if (Request.UrlReferrer != null)
                    //{
                    //    Response.Redirect(Request.UrlReferrer.ToString());
                    //}
                    //else
                        //Response.Redirect("Index.aspx");
                }
                else
                {
                    //Error Cookie
                    SigninError["ErrorMessage"] = "Your Username/Password are incorrect, Please try Again";
                    SigninError.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(SigninError);
                    Response.Redirect("SignIn.aspx");
                }
            }

        }//End Sign In Click
    }//End Class
}//End Namespace