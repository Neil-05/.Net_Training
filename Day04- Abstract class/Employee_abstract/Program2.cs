namespace oops{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new IndianEmployee(101, "Neil", 50000);
            Employee e2 = new USEmployee(201, "Pulisic", 50, 160);

            e1.Display();
            Console.WriteLine("Salary: " + e1.CalculateSalary());

            Console.WriteLine();

            e2.Display();
            Console.WriteLine("Salary: " + e2.CalculateSalary());
        }
    }
}