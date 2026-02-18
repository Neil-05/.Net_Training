using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] phones = { "+91 9876543210", "9876543210", "+91-12345", "0091 9876543210","+91-8318386560" };
        string pattern = @"^(?:\+91[\s-]?)?\d{10}$";

        foreach (var p in phones)
            Console.WriteLine($"Is this no :{p} a valid Indian Number => {Regex.IsMatch(p, pattern)}");
    }
}
