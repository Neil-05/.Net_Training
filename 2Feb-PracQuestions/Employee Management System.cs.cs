using System;
using System.Collections.Generic;

// Employee Class
class Employee
{
    public string EmployeeId;
    public string Name;
    public string Department;
    public double Salary;
    public DateTime JoiningDate;

  
    public Employee(string id, string name, string dept, double salary, DateTime date)
    {
        EmployeeId = id;
        Name = name;
        Department = dept;
        Salary = salary;
        JoiningDate = date;
    }
}


class HRManager
{
    private List<Employee> employees = new List<Employee>();
    private int idCounter = 1;

    public void AddEmployee(string name, string dept, double salary, DateTime joinDate)
    {
        string empId = "E" + idCounter.ToString("D3"); // E001, E002...
        idCounter++;

        Employee emp = new Employee(empId, name, dept, salary, joinDate);
        employees.Add(emp);

        Console.WriteLine("Employee Added: " + empId);
    }

   
    public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
    {
        SortedDictionary<string, List<Employee>> result =
            new SortedDictionary<string, List<Employee>>();

        foreach (Employee emp in employees)
        {
            if (!result.ContainsKey(emp.Department))
            {
                result[emp.Department] = new List<Employee>();
            }

            result[emp.Department].Add(emp);
        }

        return result;
    }


    public double CalculateDepartmentSalary(string department)
    {
        double total = 0;

        foreach (Employee emp in employees)
        {
            if (emp.Department == department)
            {
                total += emp.Salary;
            }
        }

        return total;
    }


    public List<Employee> GetEmployeesJoinedAfter(DateTime date)
    {
        List<Employee> result = new List<Employee>();

        foreach (Employee emp in employees)
        {
            if (emp.JoiningDate > date)
            {
                result.Add(emp);
            }
        }

        return result;
    }
}


public class Program
{
    static void Main()
    {
        HRManager hr = new HRManager();

        hr.AddEmployee("Mukesh", "IT", 50000, new DateTime(2023, 5, 10));
        hr.AddEmployee("Rohit", "HR", 40000, new DateTime(2022, 3, 15));
        hr.AddEmployee("Aman", "Sales", 45000, new DateTime(2024, 1, 20));
        hr.AddEmployee("Neha", "IT", 55000, new DateTime(2024, 6, 5));

        Console.WriteLine("\n--- Employees By Department ---");

        var groups = hr.GroupEmployeesByDepartment();

        foreach (var dept in groups)
        {
            Console.WriteLine("\nDepartment: " + dept.Key);

            foreach (Employee emp in dept.Value)
            {
                Console.WriteLine(
                    emp.EmployeeId + " | " +
                    emp.Name + " | " +
                    emp.Salary + " | " +
                    emp.JoiningDate.ToShortDateString()
                );
            }
        }

        
        Console.WriteLine("\n--- Salary of IT Department ---");
        double itSalary = hr.CalculateDepartmentSalary("IT");
        Console.WriteLine("Total IT Salary: " + itSalary);

        
        Console.WriteLine("\n--- Employees Joined After 2023-12-31 ---");

        var recent = hr.GetEmployeesJoinedAfter(new DateTime(2023, 12, 31));

        foreach (Employee emp in recent)
        {
            Console.WriteLine(emp.EmployeeId + " - " + emp.Name);
        }
    }
}
