using Microsoft.Data.SqlClient;
using DALDemo.Models;
using System.Data;

namespace DALDemo.Data
{
    public class StudentDAL
    {
        private string connectionString =
            "Server=localhost,1433;Database=TrainingDB;User Id=sa;Password=StrongPass@123;TrustServerCertificate=True;";

        // 🔹 Add Student
        public int AddStudent(Student student)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_AddStudent", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FullName", student.FullName);
            cmd.Parameters.AddWithValue("@City", student.City);
            cmd.Parameters.AddWithValue("@Marks", student.Marks);

            SqlParameter outputId = new SqlParameter("@NewStudentId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputId);

            con.Open();
            cmd.ExecuteNonQuery();

            return (int)outputId.Value;
        }

        // 🔹 Get Student By Id
        public Student? GetStudentById(int id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_GetStudentById", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentId", id);

            con.Open();

            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Student
                {
                    StudentId = (int)reader["StudentId"],
                    FullName = reader["FullName"]?.ToString(),
                    City = reader["City"]?.ToString(),
                    Marks = (int)reader["Marks"]
                };
            }

            return null;
        }

        // 🔹 Update Marks
        public void UpdateMarks(int id, int marks)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_UpdateMarks", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentId", id);
            cmd.Parameters.AddWithValue("@Marks", marks);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // 🔹 Count Students
        public int CountStudents()
        {
            using SqlConnection con = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_CountStudents", con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter total = new SqlParameter("@Total", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(total);

            con.Open();
            cmd.ExecuteNonQuery();

            return (int)total.Value;
        }
    }
}