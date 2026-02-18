using Microsoft.Data.SqlClient;
namespace ADODEMO.TrainingDB
{
    

class Program
{
    static void Main()
    {
        string cs = "Server=localhost,1433;Database=TrainingDB;User Id=sa;Password=YourStrong@123;TrustServerCertificate=True;";

        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees ORDER BY EmployeeId";

        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string dept = reader.GetString(2);
                    decimal salary = reader.GetDecimal(3);

                    Console.WriteLine($"{id} | {name} | {dept} | {salary}");
                }
            }
        }
    }
}}