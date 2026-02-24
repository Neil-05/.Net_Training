using DALDemo.Data;
using DALDemo.Models;

class Program
{
    static void Main()
    {
        StudentDAL dal = new StudentDAL();

        // Add Student
        Student s = new Student
        {
            FullName = "Neil Parkhe",
            City = "Pune",
            Marks = 95
        };

        int newId = dal.AddStudent(s);
        Console.WriteLine($"New Student ID: {newId}");

        // Get Student
        var student = dal.GetStudentById(newId);
        Console.WriteLine($"{student?.StudentId} {student?.FullName} {student?.City} {student?.Marks}");

        // Update Marks
        dal.UpdateMarks(newId, 99);
        Console.WriteLine("Marks Updated!");

        // Count Students
        int total = dal.CountStudents();
        Console.WriteLine($"Total Students: {total}");
    }
}