using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class CustomerDetails
    {
        private static int s_customerID = 3001;
        private double _walletBalance;
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        public string EmailID { get; set; }
        public double WalletBalance { get { return _walletBalance; } }

        //Constructor
        public CustomerDetails()
        {

        }

        public CustomerDetails(string customerName, string city, string mobile, double walletBalance, string emailId)
        {
            CustomerId = $"CID{s_customerID++}";
            CustomerName = customerName;
            City = city;
            Mobile = mobile;
            EmailID = emailId;
            _walletBalance = walletBalance;
        }

        public void WalletRecharge(double amount)
        {
            _walletBalance += amount;
        }
        public void DeductBalance(double amount)
        {
            _walletBalance -= amount;
        }
    }
}