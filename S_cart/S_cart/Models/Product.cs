using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S_cart.Models
{
    public class product
    {
        public int product_id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }

    }
}