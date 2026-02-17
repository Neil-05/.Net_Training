using System;
using System.Collections.Generic;
using System.Linq;

#region Interfaces

public interface IStudent
{
    int StudentId { get; }
    string Name { get; }
    int Semester { get; }
}

public interface ICourse
{
    string CourseCode { get; }
    string Title { get; }
    int MaxCapacity { get; }
    int Credits { get; }
}

#endregion

#region Enrollment System

public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private readonly Dictionary<TCourse, List<TStudent>> _enrollments = new();

    public bool EnrollStudent(TStudent student, TCourse course)
    {
        if (student == null || course == null)
            return false;

        if (!_enrollments.ContainsKey(course))
            _enrollments[course] = new List<TStudent>();

        var students = _enrollments[course];

        // Already enrolled
        if (students.Any(s => s.StudentId == student.StudentId))
        {
            Console.WriteLine($"{student.Name} already enrolled in {course.Title}");
            return false;
        }

        // Capacity check
        if (students.Count >= course.MaxCapacity)
        {
            Console.WriteLine($"{course.Title} is at maximum capacity.");
            return false;
        }

        // Prerequisite check (only for LabCourse)
        if (course is LabCourse lab && student.Semester < lab.RequiredSemester)
        {
            Console.WriteLine($"{student.Name} does not meet semester requirement for {course.Title}");
            return false;
        }

        students.Add(student);
        Console.WriteLine($"{student.Name} successfully enrolled in {course.Title}");
        return true;
    }

    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        if (_enrollments.TryGetValue(course, out var students))
            return students.AsReadOnly();

        return new List<TStudent>().AsReadOnly();
    }

    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        return _enrollments
            .Where(e => e.Value.Any(s => s.StudentId == student.StudentId))
            .Select(e => e.Key);
    }

    public int CalculateStudentWorkload(TStudent student)
    {
        return GetStudentCourses(student).Sum(c => c.Credits);
    }
}

#endregion

#region GradeBook

public class GradeBook<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private readonly Dictionary<(TStudent, TCourse), double> _grades = new();
    private readonly EnrollmentSystem<TStudent, TCourse> _enrollmentSystem;

    public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollmentSystem)
    {
        _enrollmentSystem = enrollmentSystem;
    }

    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        if (grade < 0 || grade > 100)
            throw new ArgumentException("Grade must be between 0 and 100.");

        var enrolled = _enrollmentSystem.GetEnrolledStudents(course);
        if (!enrolled.Any(s => s.StudentId == student.StudentId))
            throw new InvalidOperationException("Student not enrolled in course.");

        _grades[(student, course)] = grade;
        Console.WriteLine($"Grade {grade} added for {student.Name} in {course.Title}");
    }

    public double? CalculateGPA(TStudent student)
    {
        var studentGrades = _grades
            .Where(g => g.Key.Item1.StudentId == student.StudentId)
            .ToList();

        if (!studentGrades.Any())
            return null;

        double totalWeighted = 0;
        int totalCredits = 0;

        foreach (var entry in studentGrades)
        {
            var course = entry.Key.Item2;
            totalWeighted += entry.Value * course.Credits;
            totalCredits += course.Credits;
        }

        return totalWeighted / totalCredits;
    }

    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        var courseGrades = _grades
            .Where(g => EqualityComparer<TCourse>.Default.Equals(g.Key.Item2, course));

        if (!courseGrades.Any())
            return null;

        var top = courseGrades.OrderByDescending(g => g.Value).First();
        return (top.Key.Item1, top.Value);
    }
}

#endregion

#region Implementations

public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Semester { get; set; }
    public string Specialization { get; set; }
}

public class LabCourse : ICourse
{
    public string CourseCode { get; set; }
    public string Title { get; set; }
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public string LabEquipment { get; set; }
    public int RequiredSemester { get; set; }
}

#endregion

#region Simulation

public class Program
{
    public static void Main()
    {
        var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();
        var gradebook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

        // Students
        var s1 = new EngineeringStudent { StudentId = 1, Name = "Alice", Semester = 3, Specialization = "AI" };
        var s2 = new EngineeringStudent { StudentId = 2, Name = "Bob", Semester = 1, Specialization = "Robotics" };
        var s3 = new EngineeringStudent { StudentId = 3, Name = "Charlie", Semester = 4, Specialization = "Cybersecurity" };

        // Courses
        var c1 = new LabCourse
        {
            CourseCode = "LAB101",
            Title = "Electronics Lab",
            MaxCapacity = 2,
            Credits = 3,
            LabEquipment = "Oscilloscope",
            RequiredSemester = 2
        };

        var c2 = new LabCourse
        {
            CourseCode = "LAB201",
            Title = "Advanced Robotics Lab",
            MaxCapacity = 1,
            Credits = 4,
            LabEquipment = "Robotic Arm",
            RequiredSemester = 3
        };

        Console.WriteLine("=== ENROLLMENT ===");

        enrollment.EnrollStudent(s1, c1); // Success
        enrollment.EnrollStudent(s2, c1); // Fail (semester)
        enrollment.EnrollStudent(s3, c1); // Success
        enrollment.EnrollStudent(s1, c1); // Fail (duplicate)
        enrollment.EnrollStudent(s3, c2); // Success
        enrollment.EnrollStudent(s1, c2); // Fail (capacity)

        Console.WriteLine("\n=== WORKLOAD ===");
        Console.WriteLine($"{s1.Name} workload: {enrollment.CalculateStudentWorkload(s1)} credits");

        Console.WriteLine("\n=== GRADES ===");

        gradebook.AddGrade(s1, c1, 85);
        gradebook.AddGrade(s3, c1, 92);
        gradebook.AddGrade(s3, c2, 88);

        Console.WriteLine("\n=== GPA ===");
        Console.WriteLine($"{s1.Name} GPA: {gradebook.CalculateGPA(s1):F2}");
        Console.WriteLine($"{s3.Name} GPA: {gradebook.CalculateGPA(s3):F2}");

        Console.WriteLine("\n=== TOP STUDENT PER COURSE ===");

        var topC1 = gradebook.GetTopStudent(c1);
        if (topC1 != null)
            Console.WriteLine($"{c1.Title} Top Student: {topC1.Value.student.Name} ({topC1.Value.grade})");

        var topC2 = gradebook.GetTopStudent(c2);
        if (topC2 != null)
            Console.WriteLine($"{c2.Title} Top Student: {topC2.Value.student.Name} ({topC2.Value.grade})");
    }
}

#endregion
