using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S_cart.Models
{
    public class Cart
    {
        public int cart_id { get; set; }
        public int user_id { get; set; }
        public int product_id { get; set; }
        public int status_code { get; set; }
        public string activation_code { get; set; }

        // 
        public string product_name { get; set; }
        public string image_url { get; set; }
        public int unit_price { get; set; }
        public int quantity { get; set; }
        //

    }
}