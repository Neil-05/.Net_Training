
class GCD
{
    public static long gcd(long a,long b)
    {
        if(b==0) return a;
        return gcd(b,a%b);
    }
    public static void Main(string[] args)
    {  Console.WriteLine("Enter two numbers to find GCD and LCM:");
       long a= long.Parse(Console.ReadLine()!); // input 1
        long b = long.Parse(Console.ReadLine()!); // input 2


        long Gcd=gcd(a,b);
        long Lcm=(a*b)/Gcd;
        Console.WriteLine("GCD is: " + Gcd);
        Console.WriteLine("LCM is " +Lcm);
    }
}
