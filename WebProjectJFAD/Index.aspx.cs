using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace WebProjectJFAD
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>();
            using (ProductDb db = new ProductDb())
            {
                //Choose three random products
                products = db.Products.OrderBy(p => Guid.NewGuid()).Take(3).ToList();
            }
            foreach (Product p in products)
            {
                //Dynamically create links in the same style as other links on the homepage for the 3 randomly choosen products from above.
                HtmlGenericControl ColDiv = new HtmlGenericControl("div");
                ColDiv.Attributes["class"] = "col-md-4";
                HtmlGenericControl article = new HtmlGenericControl("article");
                article.Attributes["class"] = "Links";
                article.Attributes["style"] = "background-image:url(" + p.MainProductImage.ToString() + ");";
                HtmlGenericControl HoverDiv = new HtmlGenericControl("div");
                HoverDiv.Attributes["class"] = "hover";
                HtmlGenericControl h4 = new HtmlGenericControl("h4");
                h4.InnerText = p.ProductName;
                HtmlGenericControl p1 = new HtmlGenericControl("p");
                p1.InnerText = p.Description;
                HtmlGenericControl p2 = new HtmlGenericControl("p");
                p2.InnerHtml = "<a href='ProductDetails.aspx?ProductId="+p.ProductId+"' class='btn btn-info btn-sm'>Go</a>";
                HoverDiv.Controls.Add(h4);
                HoverDiv.Controls.Add(p1);
                HoverDiv.Controls.Add(p2);
                article.Controls.Add(HoverDiv);
                ColDiv.Controls.Add(article);
                RandomProducts.Controls.Add(ColDiv);

            }
        }//End Page Load
    }//End Class
}//End Namespace