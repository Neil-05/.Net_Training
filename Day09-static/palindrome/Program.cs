using System;
using System.Linq;
namespace Palindrome
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a string:");
            string? str = Console.ReadLine();
            Check.IsPalindrome(str);
            Console.WriteLine($"Is the string a palindrome?\n answer: {Check.result}!");
        }
    }
}