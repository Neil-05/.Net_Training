class LargestOfThree
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter three numbers:");
        int a = int.Parse(Console.ReadLine()!);
        int b = int.Parse(Console.ReadLine()!);
        int c = int.Parse(Console.ReadLine()!);

        int max;

        if (a > b)
        {
            if (a > c)
                max = a;
            else
                max = c;
        }
        else
        {
            if (b > c)
                max = b;
            else
                max = c;
        }

        Console.WriteLine("Largest number is: " + max);
    }
}
