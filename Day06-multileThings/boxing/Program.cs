using System;

class Demo
{
    static void Main()
    {
        int n = 42;

        object boxed = n;      // boxing
        int unboxed = (int)boxed; // unboxing (explicit cast)

        Console.WriteLine($"n={n}, boxed={boxed}, unboxed={unboxed}");
    }
}
