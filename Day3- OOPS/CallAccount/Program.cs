using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsSessions
{
    public class CallAccount
    {
         public static void Main(string[] args)
        {
          Account account = new Account() { AccountId = 1, Name = "Account1" };
        string result = account.GetAccountDetails();
        Console.WriteLine(result);

        SalesAccount salesAccount = new SalesAccount()
        {
            AccountId = 1,
            Name = "Balu",
            SalesInfo = ""
        };

        var result1 = salesAccount.GetSalesAccountDetails();
        Console.WriteLine(result1);
        }
    }
}  