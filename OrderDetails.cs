using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class OrderDetails
    {
        private static int s_orderID = 1001;
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatusDetails OrderStatus { get; set; }

        public OrderDetails()
        {

        }
        public OrderDetails(string customerId, string productId, double totalPrice,
        DateTime purchaseDate, int quantity, OrderStatusDetails orderStatus)
        {
            OrderID = $"OID{s_orderID++}";
            CustomerID = customerId;
            ProductID = productId;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            OrderStatus = orderStatus;
        }

    }
}