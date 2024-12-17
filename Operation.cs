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
        public static void MainMenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("******Main Menu******");
                //show option 1. Registration 2. Login 3. Exit
                System.Console.WriteLine("1. Registration\n2. Login\n3. Exit");
                //get option
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    //call methods
                    case 1:
                        {
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            flag = false;
                            System.Console.WriteLine("Thank You");
                            break;
                        }
                }

            } while (flag);

        }
        public static void Registration()
        {
            //get name,city,mobile,balance,emailid
            System.Console.Write("Enter Name :");
            string customerName = Console.ReadLine();
            System.Console.Write("Enter City : ");
            string city = Console.ReadLine();
            System.Console.Write("Enter Mobile :");
            string mobile = Console.ReadLine();
            System.Console.WriteLine("Enter EmailID : ");
            string emailId = Console.ReadLine();
            System.Console.WriteLine("Enter Wallet Balance : ");
            double walletBalance = double.Parse(Console.ReadLine());
            //create object
            CustomerDetails customer = new(customerName, city, mobile, walletBalance, emailId);
            //show registration successful and registration id
            System.Console.WriteLine($"Registration Successful! and your ID is {customer.CustomerId}");
            //add the object to list
            customers.Add(customer);
        }
        public static void Login()
        {
            System.Console.WriteLine("******Login Menu******");
            //get Customer ID
            System.Console.WriteLine("Enter Customer ID");
            string customerId = Console.ReadLine().ToUpper();
            bool flag = false;
            foreach (CustomerDetails customer in customers)
            //check customer id is present or not
            {
                if (customerId.Equals(customer.CustomerId))
                {
                    //if present put customer object globally
                    currentLoggedInCustomer = customer;
                    //call Sub Menu
                    SubMenu();
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid Customer Details");
            }
        }


        public static void SubMenu()
        {

            bool flag = true;
            //             a.	Purchase b.	OrderHistory c.	CancelOrder d.	WalletBalance e.	WalletRecharge f.	Exit
            do
            {
                System.Console.WriteLine("******Sub Menu******");
                System.Console.WriteLine("1. Purchase\n2. Order History\n3. Cancel Order\n4. Wallet Balance\n5. Wallet Recharge\n6. Exit");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            Purchase();
                            break;

                        }
                    case 2:
                        {
                            OrderHistory();
                            break;
                        }
                    case 3:
                        {
                            CancelOrder();
                            break;
                        }
                    case 4:
                        {
                            WalletBalance();
                            break;
                        }
                    case 5:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 6:
                        {
                            flag = false;
                            System.Console.WriteLine("ThankYou");
                            break;
                        }
                }
            } while (flag);

        }
        public static void Purchase()
        {
            System.Console.WriteLine("**Purchase**");
            //Show Product List
            foreach (ProductDetails product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.ProductName} {product.Stock} {product.Price} {product.ShippingDuration}");

            }
            //Get Product Id
            System.Console.Write("Enter Product ID : ");
            string ProductID = Console.ReadLine();

            //get quantity needed
            System.Console.Write("Enter Quantity : ");
            int quantity = int.Parse(Console.ReadLine());
            //check product is valid if no show invalid product id
            bool flag = true;
            foreach (ProductDetails product in products)
            {


                if (product.ProductID.Equals(ProductID))
                {
                    flag = false;
                    if (product.Stock >= quantity)
                    {
                        //find total amount and add with delivery charge
                        double total = (quantity * product.Price) + 50;
                        //check user has available balance if no show insufficient balance
                        if (total <= currentLoggedInCustomer.WalletBalance)
                        {
                            //if he has balance deduct amount from his balance
                            currentLoggedInCustomer.DeductBalance(total);
                            //reduce product count
                            product.Stock -= quantity;
                            //create order object
                            OrderDetails order = new OrderDetails(currentLoggedInCustomer.CustomerId, ProductID, total, DateTime.Now, quantity, OrderStatusDetails.Ordered);
                            //show order created successfully and order ID
                            System.Console.WriteLine($"Ordered Successfully.\nOrderID : {order.OrderID}");
                            //add to list
                            orders.Add(order);
                            //if valid id then check quantity is available if no show insuffient quantity
                        }
                        else
                        {
                            System.Console.WriteLine("Insufficient Balance");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Insufficient Quantity");
                    }
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid Product");
            }

        }
        public static void OrderHistory()
        {
            bool flag = true;
            //System.Console.WriteLine("**Order History**");
            //show the current logged in users ordered details - if present
            foreach (OrderDetails order in orders)
            {
                if (order.CustomerID.Equals(currentLoggedInCustomer.CustomerId))
                {
                    flag = false;
                    System.Console.WriteLine($"{order.CustomerID}\n{order.OrderID}\n{order.ProductID}\n{order.PurchaseDate}\n{order.Quantity}\n{order.OrderStatus}\n{order.TotalPrice}");
                }
            }
            //else show no order history
            if (flag)
            {
                System.Console.WriteLine("No Order History");
            }
        }
        public static void CancelOrder()
        {
            System.Console.WriteLine("**Cancel Order**");
            //Show order details of current customer whose order status is ordered
            //if not present show order history is not found
            bool flag = true;
            foreach (OrderDetails order in orders)
            {
                if (currentLoggedInCustomer.CustomerId.Equals(order.CustomerID) && order.OrderStatus.Equals(OrderStatusDetails.Ordered))
                {
                    flag = false;
                    System.Console.WriteLine($"{order.OrderID} {order.CustomerID} {order.ProductID} {order.Quantity} {order.OrderStatus} {order.TotalPrice}");
                }
            }
            if (flag)
            {
                System.Console.WriteLine("No order Available");
            }
            else
            {
                //if present then get order id
                System.Console.Write("Enter Order ID : ");
                string orderID = Console.ReadLine();

                //validate order id if not present show invalid order id
                bool ordercheck = true;
                foreach (OrderDetails order in orders)
                {
                    if (currentLoggedInCustomer.CustomerId.Equals(order.CustomerID) && order.OrderStatus.Equals(OrderStatusDetails.Ordered))
                    {
                        ordercheck = false;
                        //return the order amount to current user wallet balance
                        currentLoggedInCustomer.WalletRecharge(order.TotalPrice - 50);
                        //change the order status to cancelled
                        order.OrderStatus = OrderStatusDetails.Cancelled;
                        //return the ordered quantity to product stock
                        foreach (ProductDetails product in products)
                        {
                            if (order.ProductID.Equals(product.ProductID))
                            {
                                product.Stock += order.Quantity;
                                break;
                            }
                        }
                        //show order cancelled successfully
                        System.Console.WriteLine("Order cancelled successfully");
                        break;
                    }
                }
                if (ordercheck)
                {
                    System.Console.WriteLine("Invalid Order ID");
                }

            }
        }
        public static void WalletBalance()
        {
            System.Console.WriteLine("**Wallet Balance**");
            System.Console.WriteLine($"Your Current Balance is {currentLoggedInCustomer.WalletBalance}");
        }
        public static void WalletRecharge()
        {
            System.Console.WriteLine("**Wallet Recharge");
            //Get amount to be recharged
            //if it is valid amount then add the amount to the user wallet balance and show the amount
            //else invalid amount
            System.Console.Write("Enter the amount to be recharged : ");
            double amount = double.Parse(Console.ReadLine());
            if (amount > 0)
            {
                currentLoggedInCustomer.WalletRecharge(amount);
                System.Console.WriteLine($"Wallet Balance has been successfully added..\nYour Current Wallet Balance is {currentLoggedInCustomer.WalletBalance}");
            }
            else
            {
                System.Console.WriteLine("Invalid Amount");
            }
        }

    }
}