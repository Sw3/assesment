using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assesment.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string name { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}