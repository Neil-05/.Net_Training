using Microsoft.Data.SqlClient;

public class Program
{
    public static void Main(string[] args)
    {
        string password = "YourStrong@123";

        string cs = $"Server=localhost,1433;Database=StudentDB;User Id=sa;Password={password};TrustServerCertificate=True;";

        string sql = @"SELECT StudentId, FullName, City, Marks 
                       FROM dbo.Students 
                       WHERE IsActive = 1";

        using var con = new SqlConnection(cs);
        using var cmd = new SqlCommand(sql, con);

        try
        {
            con.Open();

            using var reader = cmd.ExecuteReader();

            Console.WriteLine("Active Students:\n");

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string city = reader.GetString(2);
                int marks = reader.GetInt32(3);

                Console.WriteLine($"{id} | {name} | {city} | {marks}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
