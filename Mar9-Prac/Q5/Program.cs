using System; // Console, basic types

namespace ItTechGenie.M1.GenericsDelegates.Q1
{
    public class Program
    {
        public static void Main()
        {
            int a = 10;                   // first integer
            int b = 20;                   // second integer
            Console.WriteLine($"Before: a={a}, b={b}"); // print before swap

            Utils.Swap(ref a, ref b);     // swap integers using generic method

            Console.WriteLine($"After : a={a}, b={b}"); // print after swap

            string x = "Hello";           // first string
            string y = "World";           // second string
            Console.WriteLine($"Before: x={x}, y={y}"); // print before swap

            Utils.Swap(ref x, ref y);     // swap strings using same method

            Console.WriteLine($"After : x={x}, y={y}"); // print after swap
        }
    }

    public static class Utils
    {
        // ✅ TODO: Student must implement only this method
        // Goal: swap two variables of type T using a temporary variable.
        public static void Swap<T>(ref T a, ref T b)
        {
            // TODO: Write your code here
          // remove after implementing
          T temp =a;
          a= b;
          b= temp;
          
        }
    }
}