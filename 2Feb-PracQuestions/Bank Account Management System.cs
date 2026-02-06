using System;
using System.Collections.Generic;
using System.Linq;

class Transaction
{
    public string TransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Type { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }
}

class Account
{
    public string AccountNumber { get; set; }
    public string AccountHolder { get; set; }
    public string AccountType { get; set; }
    public double Balance { get; set; }
    public List<Transaction> TransactionHistory { get; set; }
        = new List<Transaction>();
}

class BankManager
{
    private List<Account> accounts = new List<Account>();
    private int aCounter = 1;
    private int tCounter = 1;

    public void CreateAccount(string holder, string type, double deposit)
    {
        string accNo = "AC" + aCounter++.ToString("D3");

        accounts.Add(new Account
        {
            AccountNumber = accNo,
            AccountHolder = holder,
            AccountType = type,
            Balance = deposit
        });
    }

    public bool Deposit(string accNo, double amount)
    {
        var acc = accounts.FirstOrDefault(a => a.AccountNumber == accNo);

        if (acc == null || amount <= 0) return false;

        acc.Balance += amount;

        acc.TransactionHistory.Add(new Transaction
        {
            TransactionId = "T" + tCounter++,
            TransactionDate = DateTime.Now,
            Type = "Deposit",
            Amount = amount,
            Description = "Cash Deposit"
        });

        return true;
    }

    public bool Withdraw(string accNo, double amount)
    {
        var acc = accounts.FirstOrDefault(a => a.AccountNumber == accNo);

        if (acc == null || acc.Balance < amount) return false;

        acc.Balance -= amount;

        acc.TransactionHistory.Add(new Transaction
        {
            TransactionId = "T" + tCounter++,
            TransactionDate = DateTime.Now,
            Type = "Withdrawal",
            Amount = amount,
            Description = "Cash Withdraw"
        });

        return true;
    }

    public Dictionary<string, List<Account>> GroupAccountsByType()
    {
        return accounts.GroupBy(a => a.AccountType)
                       .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Transaction> GetAccountStatement(string accNo,
                                                 DateTime from, DateTime to)
    {
        var acc = accounts.FirstOrDefault(a => a.AccountNumber == accNo);

        if (acc == null) return new List<Transaction>();

        return acc.TransactionHistory.Where(t =>
            t.TransactionDate >= from && t.TransactionDate <= to).ToList();
    }
}

class Program
{
    static void Main()
    {
        BankManager bank = new BankManager();

        bank.CreateAccount("Mukesh", "Savings", 5000);
        bank.CreateAccount("Amit", "Current", 10000);

        bank.Deposit("AC001", 2000);
        bank.Withdraw("AC001", 1500);

        Console.WriteLine("Accounts By Type:");

        var grouped = bank.GroupAccountsByType();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var a in g.Value)
                Console.WriteLine(a.AccountHolder + " - " + a.Balance);
        }

        Console.WriteLine("\nStatement AC001:");

        var list = bank.GetAccountStatement("AC001",
                    DateTime.Today.AddDays(-1),
                    DateTime.Today.AddDays(1));

        foreach (var t in list)
            Console.WriteLine(t.Type + " " + t.Amount);
    }
}
