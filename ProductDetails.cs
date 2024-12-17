using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{

    public class ProductDetails
    {
        private static int s_productId = 2001;
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
        public double ShippingDuration { get; set; }

        public ProductDetails()
        {

        }
        public ProductDetails(string productName, int stock, long price, double shippingDuration)
        {
            ProductID = $"PID{s_productId++}";
            ProductName = productName;
            Stock = stock;
            Price = price;
            ShippingDuration = shippingDuration;
        }

    }


}