using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using assesment.Models;

namespace assesment.DataAccessLayer
{
    public class WebShopInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WebShopContext>
    {
        protected override void Seed(WebShopContext context)
        {

            var productCategory = new List<ProductCategory>
            {
                new ProductCategory {CategoryName = "electronics" }
            };
            productCategory.ForEach(p => context.ProductCategories.Add(p));
            context.SaveChanges();
            var products = new List<Product>
            {
                new Product { title = "Laptop", productNumber = 1, price = 250, category= productCategory[0] }
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
            var customers = new List<Customer>
            {
                new Customer {name = "Phil" }
            };
            customers.ForEach(p => context.Customers.Add(p));
            context.SaveChanges();
            var orders = new List<Order>
            {
                new Order {products = products }
            };
            orders.ForEach(p => context.Orders.Add(p));
            context.SaveChanges();
        }

        }
}