using System;

class Program
{
    static void Main()
    {
        object[] values = { 10, "hello", true, null, 20, 5.5, 30, false };

        int sum = 0;

        foreach (object value in values)
        {
            if (value is int x)
            {
                sum += x;
            }
        }

        Console.WriteLine(sum);
    }
}
