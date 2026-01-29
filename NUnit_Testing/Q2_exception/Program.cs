using System;

namespace Q2_exception
{
    public class Program
    {
        public static int Adder(int a, int b)
        {
            // Example failure rule: overflow check
            checked
            {
                return a + b;
            }
        }

        public static int SafeAdder(int a, int b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentException("Negative numbers are not allowed");

            return a + b;
        }
    }
}