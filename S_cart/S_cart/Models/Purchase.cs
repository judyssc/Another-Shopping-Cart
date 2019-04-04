using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S_cart.Models
{
    public class Purchase
    {
        public int productid { get; set; }
        public int quantity { get; set; }
        public string product_name { get; set; }
        public string image { get; set; }
        public string productdesc { get; set; }
        public string purchasedate { get; set; }
        public string activationcode { get; set; }
    }
}