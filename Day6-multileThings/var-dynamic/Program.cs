using System;

class Demo
{
    static void Main()
    {
        var a = 10;        // int
        // a = "hi";       // ❌ compile-time error

        dynamic b = 10;    // can change at runtime
        b = "hi";          // ✅ allowed
        Console.WriteLine(b);

        // Risk: runtime error if method doesn't exist
        // Console.WriteLine(b.NotARealMethod()); // would fail at runtime
    }
}
