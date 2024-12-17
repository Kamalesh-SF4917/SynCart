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
            bool flag = false;
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
                    //SubMenu();
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
                            // Purchase();
                            break;

                        }
                    case 2:
                        {
                            // OrderHistory();
                            break;
                        }
                    case 3:
                        {
                            //  CancelOrder();
                            break;
                        }
                    case 4:
                        {
                            //   WalletBalance();
                            break;
                        }
                    case 5:
                        {
                            //  WalletRecharge();
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


    }
}