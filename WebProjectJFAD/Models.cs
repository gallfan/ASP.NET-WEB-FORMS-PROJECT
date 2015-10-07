using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebProjectJFAD
{
    public class ProductSubCategory
    {
        [Key]
        public int SubCatergoryID { get; set; }
        [Required]
        public string SubCategoryType { get; set; }
        [Required]
        public ProductCategory ProductCategory { get; set; }
    }

    public class ProductCategory
    {
        [Key]
        public int CatergoryID { get; set; }
        public string CategoryType { get; set; }
        public List<ProductSubCategory> SubCategories { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public ProductSubCategory SubCatergory { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string BrandName { get; set; }
        [Required]
        public int Stock { get; set; }
        public string MadeInCountry { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
        public string MainProductImage { get; set; }
    }

    public class OrderDetail
    {
        [Key]
        public int OderDetailId { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public Order OrderId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }

    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        public decimal TotalDue { get; set; }
        public string CreditCard { get; set; }
    }

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string County { get; set; }
        
        //public CustomerLogin CustomerLogin { get; set; }

    }

    public class CustomerLogin
    {
        [Key]
        public int CustomerLoginId { get; set; }
        [Required]
        
        public Customer Customer { get; set; }
        
        //public int CustomerId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Passowrd { get; set; }
        //public int Attempts { get; set; }
        //public DateTime LastLoggedIn { get; set; }
    }

    //public class AdminLogin
    //{
    //    [Key]
    //    public int AdminId { get; set; }
    //    [Required]
    //    public string UserName { get; set; }
    //    [Required]
    //    public string Password { get; set; }
    //}

    public class ProductImages
    {
        [Key]
        public int ProductImageId { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }

    public class ProductDb : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<ProductImages> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerLogin> CustomerLogins { get; set; }
        //public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<ProductSubCategory> SubCategories { get; set; }
        public ProductDb()
            : base("ProductDb")
        {

        }
    }

    public class CartItem
    {
        public int CartItemId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
    }

    //seed database
    public class ProductDBInitialiser : DropCreateDatabaseAlways<ProductDb>
    {
        protected override void Seed(ProductDb context)
        {
            var ProductCategorys = new List<ProductCategory>()
            {
                new ProductCategory(){CategoryType="Bags"},
                new ProductCategory(){CategoryType="Wallets"},
                new ProductCategory(){CategoryType="Cases"},
                new ProductCategory(){CategoryType="Accessories"}
            };

            var prodSubCat = new List<ProductSubCategory>() 
            {
                new ProductSubCategory(){SubCategoryType="Messenger",ProductCategory=ProductCategorys[0]},
                new ProductSubCategory(){SubCategoryType="Carrier",ProductCategory=ProductCategorys[0]},
                new ProductSubCategory(){SubCategoryType="Leather",ProductCategory=ProductCategorys[1]},
                new ProductSubCategory(){SubCategoryType="Sports",ProductCategory=ProductCategorys[1]},
                new ProductSubCategory(){SubCategoryType="Phone",ProductCategory=ProductCategorys[2]},
                new ProductSubCategory(){SubCategoryType="Tablet",ProductCategory=ProductCategorys[2]},
                new ProductSubCategory(){SubCategoryType="Belts",ProductCategory=ProductCategorys[3]},
                new ProductSubCategory(){SubCategoryType="Cufflinks",ProductCategory=ProductCategorys[3]}

            };

            var products = new List<Product>() {
                                    new Product(){
                                    SubCatergory = prodSubCat[0],
                                    ProductName= "Messenger bag",
                                    Description="HOT Men's Genuine Leather Handbag Brown Briefcase Laptop Shoulder Bag Messenger",
                                    Price=22.99m,
                                    BrandName="Levi",
                                    Stock=5,
                                    MadeInCountry="USA",
                                    Material="Leather",
                                    Size="Medium",
                                    MainProductImage="http://www.chapeau.cc/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/s/a/santorini_leather_messenger_bag_brown.jpg"
                                    },
                                    new Product(){
                                    SubCatergory = prodSubCat[1],
                                    ProductName= "Carrier bag",
                                    Description="HOT Men's Genuine Leather Handbag Brown Briefcase Laptop Shoulder Bag Messenger",
                                    Price=11.99m,
                                    BrandName="Levi",
                                    Stock=20,
                                    MadeInCountry="USA",
                                    Material="Leather",
                                    Size="Medium",
                                    MainProductImage="http://mycarrierbag.co.uk/images/source/Candy_Strip_Pink_1.jpg"
                                    },
                                    new Product(){
                                    SubCatergory = prodSubCat[2],
                                    ProductName= "Leather wallet",
                                    Description="HOT Men's Genuine Leather Handbag Brown Briefcase Laptop Shoulder Bag Messenger",
                                    Price=9.99m,
                                    BrandName="Levi",
                                    Stock=2,
                                    MadeInCountry="USA",
                                    Material="Leather",
                                    Size="Medium",
                                    MainProductImage="http://www.dalvey.com/sites/default/files/product_images/03093.jpg"
                                    },
                                    new Product(){
                                    SubCatergory = prodSubCat[3],
                                    ProductName= "Sports Wallet",
                                    Description="Wallet",
                                    Price=4.99m,
                                    BrandName="Levi",
                                    Stock=25,
                                    MadeInCountry="USA",
                                    Material="Leather",
                                    Size="Medium",
                                    MainProductImage="http://i01.i.aliimg.com/wsphoto/v0/1397692311_1/Fashion-Sports-Wallet-Canvas-Zipper-Trifold-Short-Students-Purse-Card-Bag.jpg"
                                    },
                                     new Product(){
                                    SubCatergory = prodSubCat[3],
                                    ProductName= "Sports Wallet",
                                    Description="Sports Wallet",
                                    Price=4.99m,
                                    BrandName="Levi",
                                    Stock=23,
                                    MadeInCountry="USA",
                                    Material="Leather",
                                    Size="Medium",
                                    MainProductImage="http://ep.yimg.com/ay/yhst-94975210642937/compact-sports-wallet-36.jpg"

                                    },
                                     new Product(){
                                    SubCatergory = prodSubCat[5],
                                    ProductName= "iPad cover",
                                    Description="iPad cover",
                                    Price=15.99m,
                                    BrandName="Levi",
                                    Stock=5,
                                    MadeInCountry="USA",
                                    Material="Leather",
                                    Size="Medium",
                                    MainProductImage="http://www.tabletaccessories.net/tablet-cover-images/tablet-cover-1a.jpg"
                                    },
                                     new Product(){
                                    SubCatergory = prodSubCat[5],
                                    ProductName= "Tablet Cover",
                                    Description="Tablet Cover",
                                    Price=10.99m,
                                    BrandName="Levi",
                                    Stock=12,
                                    MadeInCountry="USA",
                                    Material="Leather",
                                    Size="Medium",
                                    MainProductImage="http://cf5.souqcdn.com/item/2013/06/26/54/22/58/0/item_L_5422580_2265341.jpg"
                                    },
                                     new Product(){
                                    SubCatergory = prodSubCat[4],
                                    ProductName= "Leather S5 Cover",
                                    Description="Leather S5 Cover",
                                    Price=1.99m,
                                    BrandName="Levi",
                                    Stock=10,
                                    MadeInCountry="USA",
                                    Material="Leather",
                                    Size="Medium",
                                    MainProductImage="http://product-images.highwire.com/7004786/smooth-matte-finish-wallet-phone-case-for-samsung-galaxy-s5-phone-in-many-metallic-colors-blue-7.jpg"
                                    },
                                     new Product(){
                                    SubCatergory = prodSubCat[4],
                                    ProductName= "iPhone Cover",
                                    Description="iPhone Cover",
                                    Price=3.99m,
                                    BrandName="Levi",
                                    Stock=10,
                                    MadeInCountry="USA",
                                    Material="Leather",
                                    Size="Medium",
                                    MainProductImage="http://www.phonecasesaccessories.com/images/mobile-phone-cases.jpg"
                                    },
                                     new Product(){
                                    SubCatergory = prodSubCat[7],
                                    ProductName= "Cuff Links",
                                    Description="Cuff Links",
                                    Price=4.99m,
                                    BrandName="Levi",
                                    Stock=10,
                                    MadeInCountry="USA",
                                    Material="Silver",
                                    Size="Medium",
                                    MainProductImage="http://www.cufflinksdepot.com/mm5/graphics/00000002/lg/71CL1001.jpg"
                                    },
                                     new Product(){
                                    SubCatergory = prodSubCat[7],
                                    ProductName= "Silver Cuff links",
                                    Description="Silver Cuff links",
                                    Price=40.99m,
                                    BrandName="Levi",
                                    Stock=10,
                                    MadeInCountry="USA",
                                    Material="Leather",
                                    Size="Medium",
                                    MainProductImage="http://vanesonsnx.com/sites/default/files/gallery/8_5.jpg"
                                    },
                                     new Product(){
                                    SubCatergory = prodSubCat[6],
                                    ProductName= "Red Belt",
                                    Description="HOT Men's Genuine red Leather ",
                                    Price=3.99m,
                                    BrandName="Levi",
                                    Stock=16,
                                    MadeInCountry="USA",
                                    Material="Leather",
                                    Size="Medium",
                                    MainProductImage="http://foster.co.uk/wp-content/uploads/Belt_Red_Coil_web.jpg"
                                    },
                                     new Product(){
                                    SubCatergory = prodSubCat[6],
                                    ProductName= "Leather belt",
                                    Description=" Genuine Leather belt Brown ",
                                    Price=44.99m,
                                    BrandName="Levi",
                                    Stock=22,
                                    MadeInCountry="Ire",
                                    Material="Leather",
                                    Size="Medium",
                                    MainProductImage="http://newsofthesouth.com/wp-content/uploads/2014/04/mens-belts-felipe-azul.jpg"
                                    },
            };

            var customers = new List<Customer>() { new Customer() { FirstName = "John ", Lastname = "Cahill", PhoneNumber = "08721659615", EmailAddress = "JC@live.ie", AddressLine1 = "Charlestown", County ="Mayo",City="Mayo"},
                                                  new Customer() { FirstName = "Alan ", Lastname = "Lawless", PhoneNumber = "0872825822", EmailAddress = "Alan@live.ie", AddressLine1 = "Castlebar", County ="Mayo",City="Mayo"}
            };
            var customerlogins = new List<CustomerLogin>() {new CustomerLogin(){Customer=customers[0],UserName="JohnC",Passowrd="5f4dcc3b5aa765d61d8327deb882cf99"},
                                                            new CustomerLogin(){Customer=customers[1],UserName="alanL",Passowrd="8980773d4785a8bdec7235f58934d60b"}
            };

            var images = new List<ProductImages>() { 
                new ProductImages(){Product = products[0],ImageUrl="http://img2-2.timeinc.net/toh/i/g/products/1009-plastic-bags/00-plastic-bags.jpg"},
                new ProductImages(){Product = products[0],ImageUrl="http://www.earth911.com/content/uploads/2013/03/1-7-Plastic-Bags1.jpg"}, 
                new ProductImages(){Product = products[0],ImageUrl="http://mycarrierbag.co.uk/images/source/Candy_Strip_Pink_1.jpg"}};


            images.ForEach(pc => context.Images.Add(pc));
            customers.ForEach(pc => context.Customers.Add(pc));
            customerlogins.ForEach(pc => context.CustomerLogins.Add(pc));
            products.ForEach(pc => context.Products.Add(pc));
            prodSubCat.ForEach(pc => context.SubCategories.Add(pc));
            ProductCategorys.ForEach(pc => context.ProductCategorys.Add(pc));
            context.SaveChanges();
            context.Database.ExecuteSqlCommand("CREATE PROCEDURE [dbo].[SignIn] @EUsername nvarchar(Max), @EPassword nvarchar(Max), @ECustomerID int output AS DECLARE @IUsername nvarchar(max), @IPassword nvarchar(max) SELECT @IUsername = UserName, @IPassword = Passowrd FROM CustomerLogins WHERE UserName = @EUsername IF @IUsername is null BEGIN RETURN 99 END IF @IPassword <> @EPassword BEGIN RETURN 99 END SELECT @ECustomerID = Customer_CustomerId FROM CustomerLogins AS CL INNER JOIN Customers AS C ON Cl.Customer_CustomerId = C.CustomerId WHERE UserName=@EUsername RETURN 0");
            context.Database.ExecuteSqlCommand("CREATE PROCEDURE [dbo].[spInsertCustomer] @CustomerId int OUTPUT, @FirstName Varchar(50), @LastName Varchar(50), @AddressLine1 Varchar(50), @AddressLine2 Varchar(50),@EmailAddress Varchar(50),@Telephone int,@City Varchar(50),@County Varchar(50) AS Begin SET NOCOUNT ON; IF EXISTS(SELECT CustomerId FROM dbo.Customers WHERE EmailAddress = @EmailAddress) BEGIN SELECT -1 END BEGIN INSERT INTO dbo.Customers (FirstName, Lastname, PhoneNumber, EmailAddress, AddressLine1, AddressLine2, City, County) VALUES (@FirstName, @LastName, @AddressLine1, @AddressLine2, @EmailAddress, @Telephone, @City, @County) END SELECT @CustomerId = SCOPE_IDENTITY() End");
            context.Database.ExecuteSqlCommand("CREATE PROCEDURE [dbo].[spInsertCustomerLogin] @UserName Varchar(50), @Password Varchar(50),@CustomerId int AS Begin INSERT INTO dbo.CustomerLogins (Customer_CustomerId, UserName, Passowrd) VALUES  (@CustomerId, @UserName, @Password) End");

            base.Seed(context);
        }
    }
}