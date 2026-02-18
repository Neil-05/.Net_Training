class BankAccount
{
    
    static void Main()
    {
        int balance = 10000;

        Console.WriteLine("Enter withdrawal amount:");
        int amount = int.Parse(Console.ReadLine());
        try
        {
            
        
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be greater than zero.");
        }
        else if (amount > balance)
        {
            throw new InvalidOperationException("Insufficient funds for this withdrawal.");
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"Withdrawal successful. New balance: {balance}");
        }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Transaction attempt logged.");
        }


    }
}
