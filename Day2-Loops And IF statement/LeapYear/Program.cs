class LeapYear
{
    public static void Main(string[] args)
    {
        int year = int.Parse(Console.ReadLine()!);

        if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            Console.WriteLine("Leap Year");
        else
            Console.WriteLine("Not a Leap Year");
    }
}
