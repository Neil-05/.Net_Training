public class Employee
{
    public int Id{get;set;}
    public string Name{get;set;}
    public string Email{get;set;}

    public double Salary{get;set;}

    public Employee(int id,string name,string email, double salary){
        Id=id;
        Name=name;
        Email=email;
        Salary=salary;
        
    }

}
public class EmployeeDetail
{
    private List<Employee> employees= new List<Employee>();
    public void AddEmployee(Employee employee)
    {
        if(employee.Salary<=0)
        {
            employee.Salary=30000;
        }
        if(string.IsNullOrEmpty(employee.Email)||!employee.Email.Contains("@") )
        {
            employee.Email="unknown@company.com";
        }
        employees.Add(employee);
    }

    public List<Employee> getDetails()
    {
        return employees;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        EmployeeDetail employeeDetail = new EmployeeDetail();
        Employee emp1 = new Employee(1,"Neil","neilparkhe@gmail.com",60000);
        Employee emp2 = new Employee(2,"Harass","harass@swiftie.com",-1);
        Employee emp3 = new Employee(3,"Amul","amul.com",45000);
        employeeDetail.AddEmployee(emp1);
        employeeDetail.AddEmployee(emp2);
        employeeDetail.AddEmployee(emp3);
        foreach(Employee emp in employeeDetail.getDetails())
        {
            Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Email: {emp.Email}, Salary: {emp.Salary}");
        }
    }
}
