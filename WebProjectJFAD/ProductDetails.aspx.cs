using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProjectJFAD
{
    public partial class ProductDetails : System.Web.UI.Page
    {


        public delegate void MyDelegate();  //creating delegate

        public event MyDelegate MyEvent;    //event of the delegate

        List<CartItem> newCartList = new List<CartItem>();

        public List<string> addToBulletList = new List<string>();
        ProductDb db = new ProductDb();

        protected void Page_Load(object sender, EventArgs e)
        {

            if ((List<CartItem>)Session["listCartItems"] != null)
            {


                newCartList = (List<CartItem>)Session["listCartItems"];
            }

            if (!IsPostBack)
            {

                ProductDTO p = getProduct();    //gets information on the incoming product

                IEnumerable<string> img = GetImages(p);     //get images on the incoming product

                string largeImage = img.First();
                string smallImage1 = img.Skip(1).First();
                string smallImage2 = img.Last();

                DisplayImages(largeImage, smallImage1, smallImage2);    //method to displays images of product on page

                //displays product information the page
                lblProductTitle.Text = String.Format("{0} Price {1:c2}", p.ProductName, p.Price);
                lblProductInfo.Text = String.Format("{0}", p.Description);

                //sends the following 4 pieces of information to the addToList method so a list of strings will be added to addToBulletList
                if (p.MadeInCountry != null)
                    addToList("Made In :", p.MadeInCountry);

                if (p.Material != null)
                    addToList("Material :", p.Material);

                if (p.Size != null)
                    addToList("Size :", p.Size);

                if (p.Colour != null)
                    addToList("Colour :", p.Colour);

                foreach (var item in addToBulletList)
                {
                    bltList.Items.Add(item);    //all items that has been added to addToBulletList will be printed on a bucket lis on screen
                }
            }
        }//End Page Load

        public void DisplayImages(string largeImage, string smallImage1, string smallImage2)    //displays images of product on page
        {
            imgProduct.ImageUrl = largeImage;
            imgSmall1.ImageUrl = smallImage1;
            imgSmall2.ImageUrl = smallImage2;

        }

        public void addToList(string name, string info) //will add incoming strings to addToBulletList
        {
            addToBulletList.Add(name + " " + info);

        }

        public ProductDTO getProduct()  //gets information on the incoming product
        {
            ProductDTO p;
            if (Request.QueryString["ProductId"] != null)
            {
                int prodId = Convert.ToInt32(Request.QueryString["ProductId"]);


                p = (from prod in db.Products
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
                         BrandName = prod.BrandName,
                         SubCatergory = prod.SubCatergory
                     }).Single();


            }
            else p = null;
            return p;
        }

        public IEnumerable<string> GetImages(ProductDTO p)  //gets image ofincoming product
        {
            IEnumerable<string> img = from prodImg in db.Images
                                      join prod in db.Products on prodImg.Product.ProductId equals prod.ProductId
                                      where prod.ProductId == p.ProductId
                                      where prodImg.Product.ProductId == p.ProductId
                                      select prodImg.ImageUrl;


            return img;
        }

        protected void imgSmall1_Click(object sender, ImageClickEventArgs e)    //enlarges the image when clicked
        {
            ProductDTO p = getProduct();

            IEnumerable<string> img = GetImages(p);

            string largeImage, smallImage1, smallImage2;

            if (imgProduct.ImageUrl != img.Skip(1).First())
            {
                largeImage = img.Skip(1).First();

                smallImage1 = img.First();
                smallImage2 = img.Last();
            }
            else
            {
                largeImage = img.First();
                smallImage1 = img.Skip(1).First();
                smallImage2 = img.Last();
            }
            DisplayImages(largeImage, smallImage1, smallImage2);
        }

        protected void imgSmall2_Click(object sender, ImageClickEventArgs e)    //enlarges the image when clicked
        {
            ProductDTO p = getProduct();

            IEnumerable<string> img = GetImages(p);

            string largeImage, smallImage1, smallImage2;

            if (imgProduct.ImageUrl != img.Last())
            {
                largeImage = img.Last();
                smallImage1 = img.Skip(1).First();
                smallImage2 = img.First();
            }
            else
            {
                largeImage = img.First();
                smallImage1 = img.Skip(1).First();
                smallImage2 = img.Last();
            }

            DisplayImages(largeImage, smallImage1, smallImage2);
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)   //when the addToCart has been clicked
        {
            if (IsValid)
            {
                MyEvent += new MyDelegate(IsQuantityInStock);
                MyEvent += new MyDelegate(UpdateNoOfItems);
                MyEvent();  //myEvent has been raised
            }
        }

        public void UpdateNoOfItems()   //updates the number of items beside "Cart" text in the navigation bar
        {
            int noOfItems = 0;

            foreach (var item in newCartList)
            {
                noOfItems += item.Quantity;
            }

            Site myMaster = this.Master as Site;
            HyperLink cartHyperlink = myMaster.FindControl("hlCart") as HyperLink;

            if (noOfItems > 0)
            {
                cartHyperlink.Attributes.Add("style", "font-family: sans-serif");
                cartHyperlink.Text = String.Format("<span class='glyphicon glyphicon-shopping-cart'></span> Cart ({0})", noOfItems);


            }

        }

        public void IsQuantityInStock()     //checks to see if the number a customer inserts into "Quantity" textbox and checks if the product has enough items in stock
        {
            if (txtQuantity.Text != "")
            {
                ProductDTO p = getProduct();
                if (p.Stock < Convert.ToInt32(txtQuantity.Text))
                {
                    lblError.Text = String.Format("* There's only {0} {1}'s left in stock", p.Stock, p.ProductName);    //an error will appear if it doesnt
                }
                else
                {
                    CartItem newCartItem = new CartItem();
                    newCartItem.ProductId = p.ProductId;
                    newCartItem.Quantity = Convert.ToInt32(txtQuantity.Text);
                    newCartItem.Price = p.Price * newCartItem.Quantity;
                    newCartItem.ProductName = p.ProductName;
                    IEnumerable<string> img = GetImages(p);
                    newCartItem.ImageUrl = img.First();

                    newCartList.Add(newCartItem);

                    Session["listCartItems"] = newCartList; //if there is enough items in stock it is added to a session
                }
            }
            else
            {
                Response.Redirect("~/404.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)    //sends back to previous page
        {
            ProductDTO p = getProduct();
            Response.Redirect("~/Products.aspx?" + "SubCategoryID=" + p.SubCatergory.SubCatergoryID);

        }

        protected void btnEmptyCart_Click(object sender, EventArgs e)   //empties the shopping cart
        {
            Site myMaster = this.Master as Site;
            HyperLink cartHyperlink = myMaster.FindControl("hlCart") as HyperLink;

            cartHyperlink.Attributes.Add("style", "font-family: sans-serif");
            cartHyperlink.Text = String.Format("<span class='glyphicon glyphicon-shopping-cart'></span> Cart");
            Session.Clear();
        }
    }//End Class 
}//End Namespace