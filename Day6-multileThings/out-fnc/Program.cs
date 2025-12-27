namespace Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SomeClass someClass = new SomeClass();
            int number = 16;
            int square = someClass.MultiMath(number, out int sqrtValue, out int halfValue, out int addby3);
            Console.WriteLine($"For number: {number}");
            Console.WriteLine($"Square: {square}");
            Console.WriteLine($"Square Root: {sqrtValue}"); 
            Console.WriteLine($"Half Value: {halfValue}");
            Console.WriteLine($"Added by 3: {addby3}");
        }
    }
    public class SomeClass
    {
        public int MultiMath(int a, out int sqrtValue, out int halfValue, out int addby3)
        {
            sqrtValue = (int)Math.Sqrt(a);
            halfValue = a / 2;
            addby3 = a + 3;
            return a * a;
        }
    }
}