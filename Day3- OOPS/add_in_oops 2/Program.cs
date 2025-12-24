namespace oops{
    public class AddNumber 
    {
        private int x;
        private int y;
        public AddNumber(int a,int b)
        {
            x=a;
            y=b;
            
        }
        public int add()
        {
            return x+y;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            AddNumber obj=new AddNumber(5,11);
            Console.WriteLine("The sum is: "+obj.add());
        }
    }
}