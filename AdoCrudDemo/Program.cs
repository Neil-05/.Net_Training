using Microsoft.Data.SqlClient;
using System;

class Program
{
    static string cs =
    "Server=localhost,1433;Database=master;User Id=sa;Password=YourStrong@123;TrustServerCertificate=True;";

    static void Main()
    {
        CreateTable();

        while (true)
        {
            Console.WriteLine("\n---- MENU ----");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Exit");
            Console.Write("Choose option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    InsertData();
                    break;
                case 2:
                    ReadData();
                    break;
                case 3:
                    UpdateData();
                    break;
                case 4:
                    DeleteData();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    static void CreateTable()
    {
        using var con = new SqlConnection(cs);
        con.Open();

        string query = @"
        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Students')
        CREATE TABLE Students(
            Id INT PRIMARY KEY IDENTITY,
            Name VARCHAR(50),
            Marks INT
        )";

        using var cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
    }

    static void InsertData()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Marks: ");
        int marks = int.Parse(Console.ReadLine());

        using var con = new SqlConnection(cs);
        con.Open();

        string query = "INSERT INTO Students (Name, Marks) VALUES (@Name, @Marks)";
        using var cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@Marks", marks);

        cmd.ExecuteNonQuery();
        Console.WriteLine("Inserted Successfully");
    }

    static void ReadData()
    {
        using var con = new SqlConnection(cs);
        con.Open();

        string query = "SELECT * FROM Students";
        using var cmd = new SqlCommand(query, con);
        using var reader = cmd.ExecuteReader();

        Console.WriteLine("\n--- Students ---");
        while (reader.Read())
        {
            Console.WriteLine($"{reader["Id"]} - {reader["Name"]} - {reader["Marks"]}");
        }
    }

    static void UpdateData()
    {
        Console.Write("Enter Name to Update: ");
        string name = Console.ReadLine();

        Console.Write("Enter New Marks: ");
        int marks = int.Parse(Console.ReadLine());

        using var con = new SqlConnection(cs);
        con.Open();

        string query = "UPDATE Students SET Marks=@Marks WHERE Name=@Name";
        using var cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@Marks", marks);

        cmd.ExecuteNonQuery();
        Console.WriteLine("Updated Successfully");
    }

    static void DeleteData()
    {
        Console.Write("Enter Name to Delete: ");
        string name = Console.ReadLine();

        using var con = new SqlConnection(cs);
        con.Open();

        string query = "DELETE FROM Students WHERE Name=@Name";
        using var cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@Name", name);

        cmd.ExecuteNonQuery();
        Console.WriteLine("Deleted Successfully");
    }
}