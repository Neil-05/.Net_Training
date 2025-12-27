using System;

class Demo
{
    static void Main()
    {
        // Value type copy
        int a = 10;
        int b = a;
        b = 99;
        Console.WriteLine($"a={a}, b={b}"); // a=10, b=99

        // Reference type copy (array is reference type)
        int[] x = { 1, 2, 3 };
        int[] y = x;
        y[0] = 999;
        Console.WriteLine($"x[0]={x[0]}, y[0]={y[0]}"); // both 999
    }
}
