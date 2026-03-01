namespace CapgeminiLinqPrac
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

        public DateOnly DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }

        public string City { get; set; }

        public Employee(int id, string firstName, string lastName, string title, DateOnly dateOfBirth, DateTime dateOfJoining, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            DateOfBirth = dateOfBirth;
            DateOfJoining = dateOfJoining;
            City = city;
        }
    }

public class Program
{
    public static List<Employee> empList = new List<Employee>
    {
        new Employee(1001, "Malcolm", "Daruwalla", "Manager", new DateOnly(1984, 1, 2), new DateTime(2011, 8, 9), "Mumbai"),
        new Employee(1002, "Asdin", "Dhalla", "AsstManager", new DateOnly(1984, 8, 20), new DateTime(2012, 7, 7), "Mumbai"),
        new Employee(1003, "Madhavi", "Oza", "Consultant", new DateOnly(1987, 11, 14), new DateTime(2015, 12, 4), "Pune"),
        new Employee(1004, "Saba", "Shaikh", "SE", new DateOnly(1990, 6, 3), new DateTime(2016, 2, 2), "Pune"),
        new Employee(1005, "Nazia", "Shaikh", "SE", new DateOnly(1991, 3, 8), new DateTime(2016, 2, 2), "Mumbai"),
        new Employee(1006, "Suresh", "Pathak", "Consultant", new DateOnly(1989, 11, 7), new DateTime(2014, 8, 8), "Chennai"),
        new Employee(1007, "Vijay", "Natrajan", "Consultant", new DateOnly(1989, 12, 2), new DateTime(2015, 6, 1), "Mumbai"),
        new Employee(1008, "Rahul", "Dubey", "Associate", new DateOnly(1993, 11, 11), new DateTime(2014, 11, 6), "Chennai"),
        new Employee(1009, "Amit", "Mistry", "Associate", new DateOnly(1992, 8, 12), new DateTime(2014, 12, 3), "Chennai"),
        new Employee(1010, "Sumit", "Shah", "Manager", new DateOnly(1991, 4, 12), new DateTime(2016, 1, 2), "Pune")
    };

    public static void Main(string[] args)
    {


            Console.WriteLine("All Employees:");
        empList.ForEach(e => Console.WriteLine($"{e.Id} - {e.FirstName} {e.LastName} - {e.Title} - {e.City}"));
            Console.WriteLine("\nEmployees not from Mumbai:");
            empList.Where(e => e.City != "Mumbai").ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} - {e.City}"));
            Console.WriteLine("\nAsstManager Employees:");

         empList.Where(e => e.Title == "AsstManager").ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName}"));
    Console.WriteLine("\nEmployees with last name starting with S:");
          empList.Where(e => e.LastName.StartsWith("S")).ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName}"));
            Console.WriteLine("\nEmployees joined before 1/1/2015:");
            empList.Where(e => e.DateOfJoining < new DateTime(2015, 1, 1)).ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} - {e.DateOfJoining.ToShortDateString()}"));
        }
}
}