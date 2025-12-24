// See https://aka.ms/new-console-template for more information

class foot_to_cm{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number you want to convert in cm");
        double n= double.Parse(Console.ReadLine());
        double res= n * 30.48;
        Console. WriteLine("The value in cm is: " + res);
    }
}