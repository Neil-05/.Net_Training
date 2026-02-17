using System;

public class UserInterface
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter customer name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Type of Employment");
            Console.WriteLine("1. Salaried");
            Console.WriteLine("2. Self-Employed");

            int typeChoice = int.Parse(Console.ReadLine());
            string employmentType = "";

            switch (typeChoice)
            {
                case 1:
                    employmentType = "Salaried";
                    break;
                case 2:
                    employmentType = "Self-Employed";
                    break;
                default:
                    employmentType = "";
                    break;
            }

            Console.WriteLine("Enter monthly income:");
            double monthlyIncome = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter existing credit dues:");
            double dues = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter credit score:");
            int creditScore = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of loan defaults:");
            int defaults = int.Parse(Console.ReadLine());

            CreditRiskProcessor processor = new CreditRiskProcessor();

            // Validation
            processor.validateCustomerDetails(
                age, employmentType, monthlyIncome,
                dues, creditScore, defaults);

            // Credit limit calculation
            double creditLimit = processor.calculateCreditLimit(
                monthlyIncome, dues, creditScore, defaults);

            Console.WriteLine("Customer Name: " + name);
            Console.WriteLine("Approved Credit Limit: ₹" + (int)creditLimit);
        }
        catch (InvalidCreditDataException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

public class CreditRiskProcessor
{
    public bool validateCustomerDetails(int age, string employmentType,
        double monthlyIncome, double dues,
        int creditScore, int defaults)
    {
        if (age < 21 || age > 65)
            throw new InvalidCreditDataException("Invalid age");

        if (employmentType != "Salaried" && employmentType != "Self-Employed")
            throw new InvalidCreditDataException("Invalid employment type");

        if (monthlyIncome < 20000)
            throw new InvalidCreditDataException("Invalid monthly income");

        if (dues < 0)
            throw new InvalidCreditDataException("Invalid credit dues");

        if (creditScore < 300 || creditScore > 900)
            throw new InvalidCreditDataException("Invalid credit score");

        if (defaults < 0)
            throw new InvalidCreditDataException("Invalid default count");

        return true;
    }

    public double calculateCreditLimit(double monthlyIncome, double dues,
        int creditScore, int defaults)
    {
        double debtRatio = dues / (monthlyIncome * 12);

        if (creditScore < 600 || defaults >= 3 || debtRatio > 0.4)
            return 50000;
      
        if (creditScore >= 750 && defaults == 0 && debtRatio < 0.25)
            return 300000;

 
        return 150000;
    }
}

public class InvalidCreditDataException : Exception
{p
    public InvalidCreditDataException(string message) : base(message)
    {
    }
}
