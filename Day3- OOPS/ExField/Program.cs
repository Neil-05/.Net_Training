using System;

namespace CAP
{
    class Employee
    {
        private int empId;
        private string name;
        private double salary;

        // Constructor with exception handling
        public Employee(int empId, string name, double salary)
        {
            if (empId <= 0)
                throw new ArgumentException("Employee ID must be positive");

            if (salary < 0)
                throw new ArgumentOutOfRangeException("Salary cannot be negative");

            this.empId = empId;
            this.name = name;
            this.salary = salary;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {empId}, Name: {name}, Salary: {salary}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Employee e = new Employee(101, "Neil", 10000);
                e.Display();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
