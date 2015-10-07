using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProjectJFAD
{
    public partial class Register : System.Web.UI.Page
    {
        //public delegate void HashPassword(string pass);
        //public event HashPassword Hp;

        public delegate void CustomerName(string fname);
        public event CustomerName cn;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
           int CustomerId = 0;
            string constr = ConfigurationManager.ConnectionStrings["ProductDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand InsertCustomer = new SqlCommand("spInsertCustomer"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        InsertCustomer.CommandType = CommandType.StoredProcedure;
                        InsertCustomer.Parameters.AddWithValue("@Email", txtEmail.Text);
                        InsertCustomer.Parameters.AddWithValue("@FName", txtFirstName.Text);
                        InsertCustomer.Parameters.AddWithValue("@LName", txtLastName.Text);
                        InsertCustomer.Parameters.AddWithValue("@Address1", txtAddress1.Text);
                        InsertCustomer.Parameters.AddWithValue("@Address2", txtAddress2.Text);
                        InsertCustomer.Parameters.AddWithValue("@City", txtCity.Text);
                        InsertCustomer.Parameters.AddWithValue("@County", txtCounty.Text);
                        InsertCustomer.Connection = con;
                        con.Open();
                        //Put customerid into variable
                        CustomerId = Convert.ToInt32(InsertCustomer.ExecuteScalar());
                        con.Close();
                    }
                }
                using (SqlCommand InsertCustomerLogin = new SqlCommand("spInsertCustomerLogin"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        InsertCustomerLogin.Parameters.AddWithValue("@UserName", txtEmail.Text);
                        InsertCustomerLogin.Parameters.AddWithValue("@Password", GetM5Hash(txtPassword.Text)); //FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "MD5");;
                        InsertCustomerLogin.Parameters.AddWithValue("@CustomerId", CustomerId);
                        InsertCustomerLogin.Connection = con;
                        con.Open();
                        con.Close();
                    }
                }

                //Bind to modal with delegate
                CustomerName custn = new CustomerName(displayName);
                custn(Label1.Text);
                
                Label1.Text = txtFirstName.Text;
                //string message = "Supplied email address has already been used";
                Label4.Text = String.Format("Supplied email address has already been used");

                switch (CustomerId)
                {
                    case -1:
                        //message = "Supplied email address has already been used.";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() { $('#MyModal1').modal('show')});</script>", false);
                        break;
                    default:
                        //CustomerName custn = new CustomerName(displayName);
                        //cn += custn;
                        //Open Modal
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() { $('#MyModal').modal('show')});</script>", false);
                        break;
                }
            }

        }//End Register Click

        //Method for convert password to Hash
        static string GetM5Hash(string input)
        {

            string output = "";

            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                foreach (byte b in data)
                {
                    output = output + b.ToString("x2");
                }

                return output;

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }

        private void displayName(string fname)
        {
            fname = Label1.Text;
        }


    }
}
