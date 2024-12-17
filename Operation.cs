using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public static class Operation
    {
        static List<CustomerDetails> customers = new List<CustomerDetails>();
        static List<OrderDetails> orders = new List<OrderDetails>();
        static List<ProductDetails> products = new List<ProductDetails>();

        static CustomerDetails currentLoggedInCustomer;
        public static void DefaultData()
        {
            customers.Add(new CustomerDetails("Ravi", "Chennai", "9885858588", 50000, "ravi@mail.com"));
            customers.Add(new("Baskaran", "Chennai", "9888475757", 60000, "baskaran@mail.com"));
            orders.Add(new OrderDetails("CID3001", "PID2001", 20000, DateTime.Now, 2, OrderStatusDetails.Ordered));
            orders.Add(new("CID3002", "PID2003", 40000, DateTime.Now, 2, OrderStatusDetails.Ordered));
            products.Add(new("Mobile (Samsung)", 10, 10000, 3));
            products.Add(new("Tablet (Lenovo)", 5, 15000, 2));
            products.Add(new("Camara (Sony)", 3, 20000, 4));
            products.Add(new("iPhone", 5, 50000, 6));
            products.Add(new("Laptop (Lenovo I3)", 3, 40000, 3));
            products.Add(new("HeadPhone (Boat)", 5, 1000, 2));
            products.Add(new("Speakers (Boat)", 4, 500, 2));
        }
    }
}