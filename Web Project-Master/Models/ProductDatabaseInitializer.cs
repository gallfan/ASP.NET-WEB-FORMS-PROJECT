using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Web_Project_Master.Models
{
    public class ProductDatabaseInitializer:DropCreateDatabaseIfModelChanges<ProductDb>
    {
        protected override void Seed(ProductDb context)
        {
            var seed = new List<Product>() { 
            new Product(){ProductName="Wallet",BrandName="Nike"}
            };
            seed.ForEach(m => context.Products.Add(m));
            base.Seed(context);
        }
    }
}