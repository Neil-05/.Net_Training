using System; // Console, ArgumentNullException

namespace ItTechGenie.M1.GenericsDelegates.Q4
{
    public class Program
    {
        public static void Main()
        {
            int sum = GenericCalculator.Apply(10, 20, (x, y) => x + y);        // addition
            Console.WriteLine($"Sum = {sum}");                                 // print

            decimal max = GenericCalculator.Apply(12.5m, 9.2m, (x, y) => x > y ? x : y); // max
            Console.WriteLine($"Max = {max}");                                 // print
        }
    }

    public static class GenericCalculator
    {
        // ✅ TODO: Student must implement only this method
        public static T Apply<T>(T a, T b, Func<T, T, T> op)
        {
            // TODO: Validate op is not null, then return op(a, b)
            if(op ==null) throw new ArgumentNullException(nameof(op)); // validate
            else return op(a,b);
          // remove after implementing
        }
    }
}