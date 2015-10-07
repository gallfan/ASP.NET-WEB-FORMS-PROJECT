using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProjectJFAD
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public delegate void SortDelegate(string s);
        public event SortDelegate Sort;
        public static string Conn_String = WebConfigurationManager.ConnectionStrings["ProductDb"].ConnectionString;
        SqlCommand command = new SqlCommand();
        SqlDataReader queryResults;
        public List<Product> products = new List<Product>();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Request.QueryString["SubCategoryID"] != null)
            {
                string qs = Request.QueryString["SubCategoryID"];
                using (SqlConnection connection = new SqlConnection(Conn_String))
                {
                    try
                    {

                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM [dbo].[Products] where SubCatergory_SubCatergoryID = @productid";
                        command.Parameters.AddWithValue("@productid", qs);
                        queryResults = command.ExecuteReader();
                        if (queryResults.HasRows)
                        {
                            while (queryResults.Read())
                            {
                                Product p = new Product()
                                {
                                    ProductName = queryResults["ProductName"].ToString(),
                                    Description = queryResults["Description"].ToString(),
                                    Price = (decimal)queryResults["Price"],
                                    MainProductImage = queryResults["MainProductImage"].ToString()

                                };
                                products.Add(p);
                            }

                        }
                        queryResults.Close();



                    }
                    catch (Exception ex)
                    {
                        label1.Text = ex.Message;
                    }

                }

            }
        }

        //protected void btnClick_Click(object sender, EventArgs e)
        //{
        //    using(var db = new ProductDb())
        //    {
        //        var prod = db.Products.ToList();
        //        foreach (Product p in prod)
        //        { 
        //            products.Add(p); 
        //        }
                
                
        //    }
        //}

      

        protected void btnSort_Click(object sender, EventArgs e)
        {
            var prod = dropDownSort.SelectedValue;
            SortDelegate srtdel = new SortDelegate(SortProducts);
            Sort += srtdel;
            if (Sort != null)
            {
                Sort(prod);
            }
            
        }

        public void SortProducts( string s)
        {
            using (var db = new ProductDb())
            {
                
                var p = from a in db.Products select a;
                switch (s)
                {
                    case "0":
                        p = p.OrderBy(a => a.ProductName);
                        break;
                    case "1":
                        p = p.OrderBy(a => a.Price);
                        break;
                    case "2":
                        p = p.OrderByDescending(a => a.Price);
                        break;
                    case "3":
                        p = p.OrderByDescending(a => a.Stock);
                        break;
                    default:
                        p = p.OrderBy(a => a.ProductName);
                        break;
                }
                foreach (Product pr in p)
                {
                    products.Add(pr);
                }
            }
        }
    }
}