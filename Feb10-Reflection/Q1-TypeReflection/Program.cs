using System.Reflection;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Salary { get; private set; }

    private string secretCode = "X9Z";

    public Employee() { }

    public Employee(int id, string name, decimal salary)
    {
        Id = id;
        Name = name;
        Salary = salary;
    }

    public void GiveRaise(decimal amount)
    {
        Salary += amount;
    }

    private string GetSecretCode() => secretCode;
}
class Program
{
    static void Main()
    {
        Employee emp = new Employee(101, "Arun", 45000);

        Type t1 = typeof(Employee);     // compile-time
        Type t2 = emp.GetType();        // runtime

        Console.WriteLine(t1.FullName);
        Console.WriteLine(t2.FullName);
        Console.WriteLine(t1 == t2);  
        
        var methods = t1.GetMethods(); // public instance + inherited public methods

        // foreach (var m in methods)
        // {
        //     Console.WriteLine($"{m.ReturnType.Name} {m.Name}()");
        // }

       

        Type t = typeof(Employee);
        FieldInfo? f = t.GetField("secretCode", BindingFlags.Instance | BindingFlags.NonPublic);

        if (f == null)
        {
            Console.WriteLine("Field not found");
            return;
        }

        object? value = f.GetValue(emp);
        Console.WriteLine("Secret Code = " + value);
    }
}