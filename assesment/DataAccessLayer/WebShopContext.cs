using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using assesment.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace assesment.DataAccessLayer
{
    public class WebShopContext : System.Data.Entity.DbContext
    {
        public WebShopContext(): base("WebshopContext")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}