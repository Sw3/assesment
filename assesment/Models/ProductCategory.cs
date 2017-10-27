using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assesment.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<ProductCategory> productCategory { get; set; }

        public static implicit operator ProductCategory(string v)
        {
            throw new NotImplementedException();
        }
    }
}