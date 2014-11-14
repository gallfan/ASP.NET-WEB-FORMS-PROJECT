using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Project_Master.Models;

namespace Web_Project_Master
{
    public partial class HomePage : System.Web.UI.Page
    {
        ProductDb db = new ProductDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Product> products = db.Products.ToList();
            foreach(Product p in products)
            {
                lbx.Items.Add(p.ProductName);
            }
            
          
        }
    }
}