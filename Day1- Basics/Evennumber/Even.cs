// See https://aka.ms/new-console-template for more information
class Even
{
    public static bool isEven(int n)
    {
        return n%2==0;
    }
    public static void Main(string[] args)
    {   
        // Even even=new Even();
        Console.WriteLine("Enter a number:");
        int n=int.Parse(Console.ReadLine());
        bool x= isEven(n);
        if(x)
        {
            Console.WriteLine("Even");
        }
        else
        {
            Console.WriteLine("Odd");
        }
    }
}
