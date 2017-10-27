using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assesment.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int productNumber { get; set; }
        public string title { get; set; }
        public double price { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ProductCategory category { get; set; }
        public List<ProductCategory> categories { get; set; }
    }
}