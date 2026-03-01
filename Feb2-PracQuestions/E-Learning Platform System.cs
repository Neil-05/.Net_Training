using System;
using System.Collections.Generic;
using System.Linq;

class Course
{
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public string Instructor { get; set; }
    public int DurationWeeks { get; set; }
    public double Price { get; set; }
    public List<string> Modules { get; set; } = new List<string>();
}

class Enrollment
{
    public int EnrollmentId { get; set; }
    public string StudentId { get; set; }
    public string CourseCode { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public double ProgressPercentage { get; set; }
}

class StudentProgress
{
    public string StudentId { get; set; }
    public string CourseCode { get; set; }
    public Dictionary<string, double> ModuleScores { get; set; }
        = new Dictionary<string, double>();
    public DateTime LastAccessed { get; set; }
}

class LearningManager
{
    private List<Course> courses = new List<Course>();
    private List<Enrollment> enrollments = new List<Enrollment>();
    private List<StudentProgress> progressList = new List<StudentProgress>();

    private int eCounter = 1;

    public void AddCourse(string code, string name, string instructor,
                          int weeks, double price, List<string> modules)
    {
        courses.Add(new Course
        {
            CourseCode = code,
            CourseName = name,
            Instructor = instructor,
            DurationWeeks = weeks,
            Price = price,
            Modules = modules
        });
    }

    public bool EnrollStudent(string sid, string code)
    {
        var c = courses.FirstOrDefault(x => x.CourseCode == code);

        if (c == null) return false;

        enrollments.Add(new Enrollment
        {
            EnrollmentId = eCounter++,
            StudentId = sid,
            CourseCode = code,
            EnrollmentDate = DateTime.Today,
            ProgressPercentage = 0
        });

        progressList.Add(new StudentProgress
        {
            StudentId = sid,
            CourseCode = code,
            LastAccessed = DateTime.Now
        });

        return true;
    }

    public bool UpdateProgress(string sid, string code,
                               string module, double score)
    {
        var p = progressList.FirstOrDefault(x =>
            x.StudentId == sid && x.CourseCode == code);

        if (p == null || score < 0 || score > 100) return false;

        p.ModuleScores[module] = score;
        p.LastAccessed = DateTime.Now;

        return true;
    }

    public Dictionary<string, List<Course>> GroupCoursesByInstructor()
    {
        return courses.GroupBy(c => c.Instructor)
                      .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Enrollment> GetTopPerformingStudents(string code, int count)
    {
        return enrollments.Where(e => e.CourseCode == code)
            .OrderByDescending(e =>
                progressList
                .First(p => p.StudentId == e.StudentId &&
                            p.CourseCode == code)
                .ModuleScores.Values.DefaultIfEmpty(0).Average())
            .Take(count)
            .ToList();
    }
}

class Program
{
    static void Main()
    {
        LearningManager manager = new LearningManager();

        manager.AddCourse("C101", "C# Mastery", "Mukesh",
            8, 5000, new List<string> { "Basics", "OOP", "LINQ" });

        manager.AddCourse("C102", "Java", "Amit",
            10, 6000, new List<string> { "Core", "JDBC" });

        manager.EnrollStudent("S1", "C101");
        manager.EnrollStudent("S2", "C101");

        manager.UpdateProgress("S1", "C101", "Basics", 90);
        manager.UpdateProgress("S1", "C101", "OOP", 85);

        manager.UpdateProgress("S2", "C101", "Basics", 70);

        Console.WriteLine("Courses By Instructor:");

        var grouped = manager.GroupCoursesByInstructor();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var c in g.Value)
                Console.WriteLine(c.CourseName);
        }

        Console.WriteLine("\nTop Performers:");

        foreach (var e in manager.GetTopPerformingStudents("C101", 2))
            Console.WriteLine(e.StudentId);
    }
}
