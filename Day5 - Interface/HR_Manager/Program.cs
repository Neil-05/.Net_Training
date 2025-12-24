public interface IEmployeeOperations
{
    void AddEmployee(Employee emp);
    void ProcessLeaves(int empId, int leaveDays);
    void UpdateWorkHours(int empId, int hours);
    void DisplayEmployee(int empId);
    void DisplayAllEmployees();
    void deleteEmployee(int empId);
}
public class Employee
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }
    public int WeekHours { get; set; }
}

public class HRemployee : IEmployeeOperations
{
    private List<Employee> employees = new List<Employee>();

    public void AddEmployee(Employee emp)
    {
        employees.Add(emp);
        Console.WriteLine($"Employee {emp.Name} added successfully.");
    }

    public void ProcessLeaves(int empId, int leaveDays)
    {
        var emp = employees.FirstOrDefault(e => e.EmpId == empId);
        if (emp != null)
        {
            Console.WriteLine($"Processed {leaveDays} leave days for {emp.Name}.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    public void UpdateWorkHours(int empId, int hours)
    {
        var emp = employees.FirstOrDefault(e => e.EmpId == empId);
        if (emp != null)
        {
            emp.WeekHours = hours;
            Console.WriteLine($"Updated work hours for {emp.Name} to {hours} hours/week.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    public void DisplayEmployee(int empId)
    {
        var emp = employees.FirstOrDefault(e => e.EmpId == empId);
        if (emp != null)
        {
            Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.Name}, Age: {emp.Age}, Salary: {emp.Salary}, Week Hours: {emp.WeekHours}");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    public void DisplayAllEmployees()
    {
        foreach (var emp in employees)
        {
            Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.Name}, Age: {emp.Age}, Salary: {emp.Salary}, Week Hours: {emp.WeekHours}");
        }
    }

    public void deleteEmployee(int empId)
    {
        var emp = employees.FirstOrDefault(e => e.EmpId == empId);
        if (emp != null)
        {
            employees.Remove(emp);
            Console.WriteLine($"Employee {emp.Name} deleted successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.\n");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IEmployeeOperations hr = new HRemployee();

        Employee emp1 = new Employee { EmpId = 1, Name = "Neil", Age = 30, Salary = 60000, WeekHours = 40 };
        Employee emp2 = new Employee { EmpId = 2, Name = "Harass", Age = 25, Salary = 50000, WeekHours = 38 };

        hr.AddEmployee(emp1);
        hr.AddEmployee(emp2);

        hr.DisplayAllEmployees();

        hr.ProcessLeaves(1, 5);
        hr.UpdateWorkHours(2, 42);

        hr.DisplayEmployee(1);
        hr.DisplayEmployee(2);

        hr.deleteEmployee(2);

           hr.DisplayEmployee(1);
        hr.DisplayEmployee(2);
    }
}