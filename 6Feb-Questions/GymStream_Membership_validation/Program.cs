using System.Numerics;

public class Membership
{
    public string Tier{ get; set;}
    public int DurationInMonths{ get; set;}

    public double BasicPricePerMonth{get;}

    public Membership(string tier, int durationInMonths)
    {
        Tier = tier;
        DurationInMonths = durationInMonths;

        
    }
}
public class Gym
{
    double BasicPricePerMonth=0;
    double discount=0;
    public bool ValidateEnrollment(string tier,int durationInMonths)
    {
        switch(tier.ToLower())
        {
            case "basic":
                BasicPricePerMonth = 1000;
                discount=0.02;
                break;
            case "premium":
                BasicPricePerMonth = 1500;
                discount=0.07;
                break;
            case "elite":
                BasicPricePerMonth = 3000;
                discount=0.12;
                break;
            default:
                throw new InvalidTierException("Invalid membership tier.");
                return false;
        }
        if(durationInMonths <= 0)
        {
            throw new ArgumentException("Duration must be greater than zero.");
            return false;   

        }
        return true;

    }
    public double CalculateTotalCost(string tier, int durationInMonths)
    {
        
        double total= BasicPricePerMonth* durationInMonths;
        return total - (total * discount);
    }

}
public class InvalidTierException : Exception
{
    public InvalidTierException(string message) : base(message)
    {
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Gym gym = new Gym();
        string tier = "Premium";
        int durationInMonths = 6;

        try
        {
            if (gym.ValidateEnrollment(tier, durationInMonths))
            {
                double totalCost = gym.CalculateTotalCost(tier, durationInMonths);
                Console.WriteLine($"Total cost for {tier} membership for {durationInMonths} months: {totalCost}");
            }
        }
        catch (InvalidTierException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}