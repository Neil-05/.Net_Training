namespace Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SomeClass someClass = new SomeClass();
            int x=int.MaxValue;
            int y=20;
            int sum = someClass.AddNumbers(x, y);
            Console.WriteLine($"Sum of {x} and {y} is: {sum}");
            int checkedSum = someClass.AddNumbersChecked(x, y);
            Console.WriteLine($"Checked Sum of {x} and {y} is: {checkedSum}");
        }
    }
    public class SomeClass
    {
        public int AddNumbers(int x, int y)
        {
            int z = x + y;
            // here round robin will take place because of int overflow !
            // so the value to the next of maximm value will be converted to minimm value of int
            // to counter this we can use checked keyword
            return z;
        }
        public int AddNumbersChecked(int x, int y)
        {
            checked
            {
                int z = x + y;
                return z;
            }
            // or we can directly use int z = checked(x + y);   
        }
    }
}