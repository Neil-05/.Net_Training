using System;
using System.Collections.Generic;

interface IExaminer
{
    void ConductExam();
}

abstract class employee
{
    public int EmployeeId { get; set; }
    public department department { get; set; }
    public abstract void DisplayRole();
}

class department
{
    public int deptId { get; set; }
    public string deptName { get; set; }
}

class HOD : employee
{
    public string hodName { get; set; }

    public override void DisplayRole()
    {
        Console.WriteLine("Role: Head of Department");
    }
}

class Examiner : employee, IExaminer
{
    public string ExaminerDetails { get; set; }
    public int RoomNo { get; set; }

    public override void DisplayRole()
    {
        Console.WriteLine("Role: Examiner");
    }

    public void ConductExam()
    {
        Console.WriteLine($"Exam conducted in Room {RoomNo}");
    }
}

class Exam
{
    public int examId { get; set; }
    public string examName { get; set; }
    public Examiner examiner { get; set; }
}

class student
{
    public int studentId { get; set; }
    public string studentName { get; set; }
    public Exam Exam { get; set; }
}

class semester
{
    public int semesterid { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Department
        department dept = new department();
        Console.Write("Enter Department ID: ");
        dept.deptId = int.Parse(Console.ReadLine());

        Console.Write("Enter Department Name: ");
        dept.deptName = Console.ReadLine();

        // Examiner
        Examiner examiner = new Examiner();
        Console.Write("Enter Examiner Employee ID: ");
        examiner.EmployeeId = int.Parse(Console.ReadLine());
        examiner.department = dept;

        Console.Write("Enter Examiner Details: ");
        examiner.ExaminerDetails = Console.ReadLine();

        Console.Write("Enter Room Number: ");
        examiner.RoomNo = int.Parse(Console.ReadLine());

        // Semester
        semester sem = new semester();
        Console.Write("Enter Semester ID: ");
        sem.semesterid = int.Parse(Console.ReadLine());

        // Exam
        Exam exam = new Exam();
        Console.Write("Enter Exam ID: ");
        exam.examId = int.Parse(Console.ReadLine());

        Console.Write("Enter Exam Name: ");
        exam.examName = Console.ReadLine();
        exam.examiner = examiner;

        // Multiple students
        List<student> students = new List<student>();

        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter details for Student {i + 1}:");

            student s = new student();

            Console.Write("Student ID: ");
            s.studentId = int.Parse(Console.ReadLine());

            Console.Write("Student Name: ");
            s.studentName = Console.ReadLine();

            s.Exam = exam;
            students.Add(s);
        }

        // Output
        Console.WriteLine("\n--- STUDENT DETAILS ---");
        foreach (student s in students)
        {
            Console.WriteLine($"ID: {s.studentId}, Name: {s.studentName}, Exam: {s.Exam.examName}");
        }

        examiner.DisplayRole();
        examiner.ConductExam();
    }
}
