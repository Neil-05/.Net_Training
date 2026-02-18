using Microsoft.Data.SqlClient;
using System.Data;

namespace CRUD
{
    public class Program
    {
        static string cs = "Server=localhost,1433;Database=TrainingDB;User Id=sa;Password=YourStrong@123;TrustServerCertificate=True;";

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== Employee Management =====");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Exit");
                Console.WriteLine("5: To XML");
                Console.Write("Choose: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1": Insert(); break;
                    case "2": Update(); break;
                    case "3": Delete(); break;
                    case "4": return;
                    case "5": ExportToXml(); break;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
        }

        static DataTable LoadTable(SqlDataAdapter adapter)
        {
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static void Insert()
        {
            using var adapter = new SqlDataAdapter("SELECT * FROM dbo.Employees", cs);
            using var builder = new SqlCommandBuilder(adapter);

            DataTable table = LoadTable(adapter);

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Dept: ");
            string dept = Console.ReadLine() ?? "";

            Console.Write("Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine() ?? "0");

            DataRow row = table.NewRow();
            row["FullName"] = name;
            row["Department"] = dept;
            row["Salary"] = salary;

            table.Rows.Add(row);

            adapter.Update(table);

            Console.WriteLine("✅ Inserted using DataAdapter");
        }

        public static void Update()
        {
            using var adapter = new SqlDataAdapter("SELECT * FROM dbo.Employees", cs);
            using var builder = new SqlCommandBuilder(adapter);

            DataTable table = LoadTable(adapter);

            Console.Write("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            DataRow? row = table.Select($"EmployeeId = {id}").FirstOrDefault();

            if (row == null)
            {
                Console.WriteLine("⚠️ Not Found");
                return;
            }

            Console.Write("New Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine() ?? "0");

            row["Salary"] = salary;

            adapter.Update(table);

            Console.WriteLine("✅ Updated using DataAdapter");
        }

        public static void Delete()
        {
            using var adapter = new SqlDataAdapter("SELECT * FROM dbo.Employees", cs);
            using var builder = new SqlCommandBuilder(adapter);

            DataTable table = LoadTable(adapter);

            Console.Write("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            DataRow? row = table.Select($"EmployeeId = {id}").FirstOrDefault();

            if (row == null)
            {
                Console.WriteLine("⚠️ Not Found");
                return;
            }

            row.Delete();

            adapter.Update(table);

            Console.WriteLine("🗑️ Deleted using DataAdapter");
        }
    
    public static void ExportToXml()
        {
            using var adapter = new SqlDataAdapter("SELECT * FROM dbo.Employees", cs);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Employees");

            ds.WriteXml("EmployeesData.xml");

            Console.WriteLine("📄 Data exported to EmployeesData.xml");
        }
    }
    }
