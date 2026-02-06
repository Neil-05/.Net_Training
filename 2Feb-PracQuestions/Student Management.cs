using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string GradeLevel { get; set; }
    public Dictionary<string, double> Subjects { get; set; }
        = new Dictionary<string, double>();
}

class SchoolManager
{
    private List<Student> students = new List<Student>();
    private int counter = 1;

    public void AddStudent(string name, string gradeLevel)
    {
        students.Add(new Student
        {
            StudentId = counter++,
            Name = name,
            GradeLevel = gradeLevel
        });
    }

    public void AddGrade(int id, string subject, double grade)
    {
        var s = students.FirstOrDefault(x => x.StudentId == id);

        if (s == null || grade < 0 || grade > 100) return;

        s.Subjects[subject] = grade;
    }

    public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
    {
        return new SortedDictionary<string, List<Student>>(
            students.GroupBy(s => s.GradeLevel)
                    .ToDictionary(g => g.Key, g => g.ToList()));
    }

    public double CalculateStudentAverage(int id)
    {
        var s = students.FirstOrDefault(x => x.StudentId == id);

        if (s == null || s.Subjects.Count == 0) return 0;

        return s.Subjects.Values.Average();
    }

    public Dictionary<string, double> CalculateSubjectAverages()
    {
        var all = students.SelectMany(s => s.Subjects);

        return all.GroupBy(x => x.Key)
                  .ToDictionary(g => g.Key,
                                g => g.Average(x => x.Value));
    }

    public List<Student> GetTopPerformers(int count)
    {
        return students.OrderByDescending(
            s => s.Subjects.Count == 0 ? 0 :
                 s.Subjects.Values.Average())
            .Take(count)
            .ToList();
    }
}

class Program
{
    static void Main()
    {
        SchoolManager manager = new SchoolManager();

        manager.AddStudent("Mukesh", "12th");
        manager.AddStudent("Amit", "11th");
        manager.AddStudent("Ravi", "12th");

        manager.AddGrade(1, "Math", 90);
        manager.AddGrade(1, "Science", 85);

        manager.AddGrade(2, "Math", 75);
        manager.AddGrade(2, "English", 80);

        manager.AddGrade(3, "Math", 95);
        manager.AddGrade(3, "Science", 92);

        Console.WriteLine("Students By Grade:");

        var grouped = manager.GroupStudentsByGradeLevel();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var s in g.Value)
                Console.WriteLine(s.Name);
        }

        Console.WriteLine("\nMukesh Average: " +
            manager.CalculateStudentAverage(1));

        Console.WriteLine("\nSubject Averages:");

        var subs = manager.CalculateSubjectAverages();

        foreach (var s in subs)
            Console.WriteLine(s.Key + " : " + s.Value);

        Console.WriteLine("\nTop Performers:");

        foreach (var s in manager.GetTopPerformers(2))
            Console.WriteLine(s.Name);
    }
}
