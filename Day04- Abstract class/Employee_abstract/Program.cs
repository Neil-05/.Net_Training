
namespace oops
{
    // Abstract base class
    abstract class Employee
    {
        private int empId;
        private string name;

        // Constructor in abstract class
        public Employee(int empId, string name)
        {
            this.empId = empId;
            this.name = name;
        }

        // Abstract method
        public abstract double CalculateSalary();

        public void Display()
        {
            Console.WriteLine($"ID: {empId}, Name: {name}");
        }
    }

    // Indian Employee
    class IndianEmployee : Employee
    {
        private double basicSalary;

        public IndianEmployee(int empId, string name, double basicSalary)
            : base(empId, name)
        {
            this.basicSalary = basicSalary;
        }

        // Override
        public override double CalculateSalary()
        {
            return basicSalary + (0.10 * basicSalary); // 10% allowance
        }
    }

    // US Employee
    class USEmployee : Employee
    {
        private double hourlyRate;
        private int hoursWorked;

        public USEmployee(int empId, string name, double hourlyRate, int hoursWorked)
            : base(empId, name)
        {
            this.hourlyRate = hourlyRate;
            this.hoursWorked = hoursWorked;
        }

        // Override
        public override double CalculateSalary()
        {
            return hourlyRate * hoursWorked;
        }
    }

    
}
