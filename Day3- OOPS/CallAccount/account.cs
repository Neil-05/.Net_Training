using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsSessions
{
    public class Account
    {
        public string Name { get; set; }
        public int AccountId { get; set; }

        public string GetAccountDetails()
        {
            return $"I am Base account . My Id is {AccountId}";
        }
      
    }
    public class SalesAccount : Account 
    {
        public string GetSalesAccountDetails()
        {
            string info = string.Empty;
            info += base.GetAccountDetails();
            info += "I am from Sales Derived class ";
            return info;
        }
        public string SalesInfo { get; set; }
    }

    public class PurchaseAccount : Account
    {
        public string PurchaseInfo { get; set; }
    }
}