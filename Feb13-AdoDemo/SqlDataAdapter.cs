using Microsoft.Data.SqlClient;
using System.Data;
namespace DataAdapter
{
    public class Program
    {
        public static void Main(string[] args)
        {



            string password = "YourStrong@123";

            string cs = $"Server=localhost,1433;Database=TrainingDB;User Id=sa;Password={password};TrustServerCertificate=True;";


            string sql = "SELECT EmployeeId,FullName, Department FROM dbo.Employees";

            using var con = new SqlConnection(cs);
            DataSet ds = new DataSet();
            using var cmd = new SqlCommand(sql, con);
            {
                con.Open();

                using var adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
            }
            ds.WriteXml("TestData.xml");
        }
    }
}