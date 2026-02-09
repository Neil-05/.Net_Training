public class BankAccount
{
    private double balance;

    public BankAccount(double initialBalance=0){
        if (initialBalance > 0)
        {
            balance= initialBalance;
        }
    }

    public void Deposit(double amount)
    {
        if(amount>0)
        balance+=amount;
        else
        Console.WriteLine("Deposit amount must be positive.");
    }

    public void Withdraw(double amount)
    {
        if(amount>balance)
        {
            Console.WriteLine("Insufficient funds.");
        }
        else if(amount<=0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
        }
        else
        {
            balance-=amount;
        }
    }
    public double GetBalance()
    {
        return balance;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        BankAccount account = new BankAccount();

        Console.WriteLine("Enter 5 transactions (D/W amount):");

        for (int i = 1; i <= 5; i++)
        {
            Console.Write($"Transaction {i}: ");
            string input = Console.ReadLine();

            string[] parts = input.Split(' ');
            char type = parts[0].ToUpper()[0];
            double amount = double.Parse(parts[1]);

            if (type == 'D')
            {
                account.Deposit(amount);
            }
            else if (type == 'W')
            {
                account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Invalid transaction type.");
            }
        }

        Console.WriteLine($"Final Balance: {account.GetBalance()}");
    }
    }
