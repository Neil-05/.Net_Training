namespace oopssession{
    public class Program
    {
        static void Main(string[] args)
        {
            Father father = new Father();
            Son son = new Son();
            System.Console.WriteLine("Father's interest: " + father.intereston());
            System.Console.WriteLine("Son's interest: " + son.intereston());
        }
    }
}