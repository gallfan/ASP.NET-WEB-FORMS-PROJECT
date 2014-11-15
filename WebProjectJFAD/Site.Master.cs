using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebProjectJFAD
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ProductDb db = new ProductDb())
            {
                List<ProductCategory> Categories = db.ProductCategorys.Include("SubCategories").ToList();

                foreach (ProductCategory pc in Categories)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes["class"] = "dropdown";
                    HyperLink link = new HyperLink();
                    //link.NavigateUrl = string.Format("Products.aspx?CategoryID={0}", pc.CatergoryID);
                    link.NavigateUrl = "#";
                    link.ID = pc.CatergoryID.ToString();
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
                    
                    foreach (ProductSubCategory psc in pc.SubCategories)
                    {
                        HtmlGenericControl li2 = new HtmlGenericControl("li");
                        HyperLink Sublink = new HyperLink();
                        Sublink.NavigateUrl = string.Format("Products.aspx?SubCatergoryID={0}", psc.SubCatergoryID);
                        Sublink.Text = psc.SubCategoryType;
                        Sublink.ID = psc.SubCatergoryID.ToString();
                        li2.Controls.Add(Sublink);
                        ul.Controls.Add(li2);
                    }
                    NavList.Controls.Add(li);
                }
            }
        }
    }
}