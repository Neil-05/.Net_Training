namespace Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SomeClass someClass = new SomeClass();
            string result = someClass.SomeMethod(42);
            Console.WriteLine(result);
            int inp1= 10;
            int inp2= 20;
            Console.WriteLine($"Prev Inputs: {inp1}, {inp2}");
            int sum = someClass.SomeMethod(ref inp1,ref inp2); // we need to assign the value then only the ref keyword will work8
            Console.WriteLine($"New Inputs: {inp1}, {inp2}"); 
            Console.WriteLine($"Sum: {sum}");
        }
    }
    public class SomeClass
    {
        public string SomeMethod(int n)
        {
            return $"Number: {n}";
        }
        public int SomeMethod(ref int a,ref int b)
        {

            a += 5;
            b += 10;   
            return a + b;
            
        }
    }
}