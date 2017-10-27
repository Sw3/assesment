using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assesment.Models
{
    public class Order
    {
        public int ID { get; set; }
        public ICollection<Product> products { get; set; }
    }
}