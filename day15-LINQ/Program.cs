namespace LinqPractice{
    
    class Program
    {
        static void Main()
        {
            // Departments
            var departments = new List<Department>
            {
                new Department { DeptId = 1, DeptName = "HR" },
                new Department { DeptId = 2, DeptName = "IT" },
                new Department { DeptId = 3, DeptName = "Sales" } // ✅ New Department
            };

            // Employees
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Neil", City = "Pune", Salary = 50000, IsActive = true, DeptId = 1 },
                new Employee { Id = 2, Name = "Harsh", City = "Mumbai", Salary = 60000, IsActive = false, DeptId = 2 },
                new Employee { Id = 3, Name = "Aman", City = "Pune", Salary = 55000, IsActive = true, DeptId = 3 },
                new Employee { Id = 4, Name = "Riya", City = "Delhi", Salary = 58000, IsActive = false, DeptId = 3 }
            };

            // 1️⃣ JOIN OUTPUT (after adding Sales + employees)
            Console.WriteLine("---- Employee Join Output ----");
            var joinResult =
                from e in employees
                join d in departments on e.DeptId equals d.DeptId
                select new
                {
                    e.Name,
                    d.DeptName,
                    e.City,
                    e.Salary
                };

            foreach (var item in joinResult)
                Console.WriteLine($"{item.Name} | {item.DeptName} | {item.City} | {item.Salary}");

            // 2️⃣ LINQ: Show only inactive employees
            Console.WriteLine("\n---- Inactive Employees ----");
            var inactiveEmployees = employees.Where(e => !e.IsActive);

            foreach (var e in inactiveEmployees)
                Console.WriteLine(e.Name);

            // 3️⃣ Group employees by City (after join) and count
            Console.WriteLine("\n---- Employee Count By City ----");
            var cityGroup =
                joinResult
                .GroupBy(x => x.City)
                .Select(g => new { City = g.Key, Count = g.Count() });

            foreach (var c in cityGroup)
                Console.WriteLine($"{c.City} : {c.Count}");

            // 4️⃣ Generic method GetTopN<T>
            Console.WriteLine("\n---- Top 2 Employees (by list order) ----");
            var top2 = GetTopN(employees, 2);
            foreach (var e in top2)
                Console.WriteLine(e.Name);

            // 5️⃣ Highest salary employee
            Console.WriteLine("\n---- Highest Salary Employee ----");
            var highestSalaryEmployee =
                employees.OrderByDescending(e => e.Salary).First();

            Console.WriteLine($"{highestSalaryEmployee.Name} : {highestSalaryEmployee.Salary}");
        }

        // 4️⃣ Generic Method
        public static List<T> GetTopN<T>(List<T> list, int n) 
        {
            return list.Take(n).ToList();
        }
    }
}
