using Microsoft.Data.SqlClient;

namespace Search
{
    class Program
    {
        static void Main()
        {
            string password = "YourStrong@123";

            string cs = $"Server=localhost,1433;Database=TrainingDB;User Id=sa;Password={password};TrustServerCertificate=True;";

            Console.Write("Enter Department (e.g., IT): ");
            string dept = Console.ReadLine() ?? "";

            string sql = @"SELECT EmployeeId, FullName, Salary
                           FROM dbo.Employees
                           WHERE Department = @dept
                           ORDER BY Salary DESC";

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@dept", dept);

            con.Open();

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                Console.WriteLine($"{r["EmployeeId"]} | {r["FullName"]} | {r["Salary"]}");
            }
        }
    }
}
