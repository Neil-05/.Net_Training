public class Cab
{
    public virtual int  CalculateFare(int km)
    {
        return 0;
    }
}
public class Mini : Cab
{
    public override int CalculateFare(int km)
    {
        return 10*km;
    }
}
public class Sedan : Cab
{
    public override int CalculateFare(int km)
    {
        return (15*km)+50;
    }

}
public class SUV : Cab
{
    public override int CalculateFare(int km)
    {
        return (18*km)+100;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Cab ride= new Cab();
        Console.WriteLine("Enter the Kms");
        int km=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the type of cab \n 1.Mini \n 2.Sedan \n 3.SUV");
        int type=int.Parse(Console.ReadLine());
        switch(type)
        {
            case 1:
                ride = new Mini();
                break;
            case 2:
                ride = new Sedan();
                break;
            case 3:
                ride = new SUV();
                break;
        }
        Console.WriteLine("The fare is: {0}", ride.CalculateFare(km));
    }
}
