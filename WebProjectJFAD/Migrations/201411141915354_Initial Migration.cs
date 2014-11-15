namespace WebProjectJFAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.CustomerLogins",
                c => new
                    {
                        CustomerLoginId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Passowrd = c.String(nullable: false),
                        Attempts = c.Int(nullable: false),
                        LastLoggedIn = c.DateTime(nullable: false),
                        Customer_CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerLoginId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId, cascadeDelete: true)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Lastname = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        AddressLine1 = c.String(nullable: false),
                        AddressLine2 = c.String(),
                        City = c.String(nullable: false),
                        County = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ProductImageId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductImageId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BrandName = c.String(),
                        Stock = c.Int(nullable: false),
                        MadeInCountry = c.String(),
                        Material = c.String(),
                        Size = c.String(),
                        Colour = c.String(),
                        SubCatergory_SubCatergoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductSubCategories", t => t.SubCatergory_SubCatergoryID, cascadeDelete: true)
                .Index(t => t.SubCatergory_SubCatergoryID);
            
            CreateTable(
                "dbo.ProductSubCategories",
                c => new
                    {
                        SubCatergoryID = c.Int(nullable: false, identity: true),
                        SubCategoryType = c.String(nullable: false),
                        ProductCategory_CatergoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubCatergoryID)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategory_CatergoryID, cascadeDelete: true)
                .Index(t => t.ProductCategory_CatergoryID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        CatergoryID = c.Int(nullable: false, identity: true),
                        CategoryType = c.String(),
                    })
                .PrimaryKey(t => t.CatergoryID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OderDetailId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        OrderId_OrderId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId_OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.OrderId_OrderId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        TotalDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId, cascadeDelete: true)
                .Index(t => t.Customer_CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderId_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ProductImages", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SubCatergory_SubCatergoryID", "dbo.ProductSubCategories");
            DropForeignKey("dbo.ProductSubCategories", "ProductCategory_CatergoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.CustomerLogins", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_CustomerId" });
            DropIndex("dbo.OrderDetails", new[] { "Product_ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId_OrderId" });
            DropIndex("dbo.ProductSubCategories", new[] { "ProductCategory_CatergoryID" });
            DropIndex("dbo.Products", new[] { "SubCatergory_SubCatergoryID" });
            DropIndex("dbo.ProductImages", new[] { "Product_ProductId" });
            DropIndex("dbo.CustomerLogins", new[] { "Customer_CustomerId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.ProductSubCategories");
            DropTable("dbo.Products");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerLogins");
            DropTable("dbo.AdminLogins");
        }
    }
}
