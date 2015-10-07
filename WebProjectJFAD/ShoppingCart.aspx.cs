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
    public partial class WebForm4 : System.Web.UI.Page
    {
        private static string conString = WebConfigurationManager.ConnectionStrings["ProductDb"].ConnectionString;  //connection string

        ProductDb db = new ProductDb();
        public List<CartItem> newCartList = new List<CartItem>();   //newCartList will be displayed on screen
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((List<CartItem>)Session["listCartItems"] != null)
                newCartList = (List<CartItem>)Session["listCartItems"];

            Session["listCartItems"] = newCartList;     //everything that was saved in the session will be added to newCartList
        }//End Load

        protected void btnPurchase_Click(object sender, EventArgs e)    //when the purchase button is clicked
        {
            if (IsValid)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {

                    HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                    Site master = (Site)this.Master;

                    Customer cust = new Customer();
                    cust = master.ReturnCustomer(ticket.Name);

                    newCartList = (List<CartItem>)Session["listCartItems"];
                    int newOrderId = 0;
                    decimal euros = 0;
                    int newStock = 0;

                    foreach (var item in newCartList)   //gets the overall price of all the products and puts them in the "euros" variable
                    {
                        ProductDTO p = getProduct(item.ProductId);
                        euros += item.Price;
                    }

                    SqlConnection connection = new SqlConnection();

                    SqlCommand mySQLCommand = new SqlCommand();


                    SqlParameter param;

                    try
                    {
                        connection = new SqlConnection(conString);
                        mySQLCommand.Connection = connection;

                        connection.Open();
                        mySQLCommand.CommandText = "INSERT INTO Orders (OrderDate, DueDate, TotalDue, Customer_CustomerId, CreditCard) VALUES (@OrderDate, @DueDate, @TotalDue, @Customer_CustomerId, @CreditCard); SELECT SCOPE_IDENTITY() AS [orderId]";
                        mySQLCommand.Connection = connection;
                        param = new SqlParameter("@OrderId", SqlDbType.Int);    //creates a unique primary key this order in OrderId
                        param.Direction = ParameterDirection.Output;
                        mySQLCommand.Parameters.Add(param);
                        mySQLCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                        mySQLCommand.Parameters.AddWithValue("@DueDate", DateTime.Now.AddDays(5));
                        mySQLCommand.Parameters.AddWithValue("@TotalDue", euros);
                        mySQLCommand.Parameters.AddWithValue("@CreditCard", txtCreditCard.Text);
                        mySQLCommand.Parameters.AddWithValue("@Customer_CustomerId", cust.CustomerId);
                        
                        newOrderId = Convert.ToInt32(mySQLCommand.ExecuteScalar());  //stores the Order Id in the newOrderId

                    }
                    catch (Exception ex)    //error appears at the end of the page if is not entered
                    {
                        lblError.Text = "An Error has occurred when making a purchase, please try again"; //ex.Message;
                    }
                    finally
                    {
                        connection.Close();
                    }

                    int i = 0;
                    foreach (var item in newCartList)
                    {
                        i += 1;
                        ProductDTO p = getProduct(item.ProductId);
                        newStock = p.Stock - item.Quantity;     //gets the new stock to add to "Stock" for each Product in the Proucts table

                        try
                        {
                            connection = new SqlConnection(conString);
                            mySQLCommand.Connection = connection;

                            connection.Open();

                            //inserts details into the orders details table

                            mySQLCommand.CommandText = "INSERT INTO OrderDetails (Quantity, OrderId_OrderId, Product_ProductId) VALUES (@Quantity" + i + ", @OrderId1" + i + ", @Product_ProductId" + i + ")";
                            mySQLCommand.Connection = connection;
                            mySQLCommand.Parameters.AddWithValue("@Quantity" + i + "", item.Quantity);
                            mySQLCommand.Parameters.AddWithValue("@Product_ProductId" + i + "", item.ProductId);
                            mySQLCommand.Parameters.AddWithValue("@OrderId1" + i + "", newOrderId);

                            mySQLCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            lblError.Text = "An Error has occurred when making a purchase, please try again";
                            //lblError.Text = ex.Message;
                        }
                        finally
                        {
                            connection.Close();
                        }


                        try
                        {
                            connection = new SqlConnection(conString);
                            mySQLCommand.Connection = connection;

                            //updates the Products table because the amount in Stock has changed

                            connection.Open();

                            mySQLCommand.CommandText = "UPDATE Products SET Stock = @newStock" + i + " WHERE ProductId = @prodId" + i + "";
                            mySQLCommand.Connection = connection;
                            mySQLCommand.Parameters.AddWithValue("@newStock" + i + "", newStock);
                            mySQLCommand.Parameters.AddWithValue("@prodId" + i + "", p.ProductId);
                            mySQLCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            lblError.Text = "An Error has occurred when making a purchase, please try again";
                            //lblError.Text = ex.Message;
                        }
                        finally
                        {
                            connection.Close();
                        }

                    }


                    Session.Clear();
                    Response.Redirect("~/OrderComplete.aspx");
               }//end of if authorisation

                else
                {
                    Response.Redirect("~/SignIn.aspx");
                }
                    

               

            }//end of IsValid


        }

        public ProductDTO getProduct(int prodId)    //gets details of a product
        {
            var p = (from prod in db.Products
                     // join pImg in db.Images on prod.ProductId equals pImg.Product
                     where prod.ProductId == prodId
                     select new ProductDTO
                     {
                         ProductId = prod.ProductId,
                         ProductName = prod.ProductName,
                         Price = prod.Price,
                         MadeInCountry = prod.MadeInCountry,
                         Material = prod.Material,
                         Stock = prod.Stock,
                         Size = prod.Size,
                         Description = prod.Description,
                         Colour = prod.Colour,
                         BrandName = prod.BrandName
                     }).Single();

            return p;
        }
    }//End Class
}//End Namespace