using System;
using System.Collections.Generic;

// Custom delegate
delegate void ReappearAlert(Student<int> student);

public class Student<TMark>
{
    public int Rank { get; set; }
    public string Name { get; set; }
    public TMark S1 { get; set; }
    public TMark S2 { get; set; }
    public double Average { get; private set; }

    // Event
    public event Action<Student<TMark>> StudentPassed;

    public Student(string name, TMark s1, TMark s2)
    {
        Name = name;
        S1 = s1;
        S2 = s2;
        CalculateAverage();
    }

    private void CalculateAverage()
    {
        Average = (Convert.ToDouble(S1) + Convert.ToDouble(S2)) / 2;
    }

    // Method to trigger event
    public void Evaluate()
    {
        if (Average >= 40)
        {
            StudentPassed?.Invoke(this);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var students = new List<Student<int>>
        {
            new Student<int>("Cho", 85, 90),
            new Student<int>("Tilu", 78, 82),
            new Student<int>("Venki", 82, 78),
            new Student<int>("Mukesh", 1, 70),
            new Student<int>("Neil", 95, 93),
            new Student<int>("Harsh", 30, 35),
            new Student<int>("Jeet", 22, 60)
        };

        // Subscribe to event
        foreach (var s in students)
        {
            s.StudentPassed += st =>
                Console.WriteLine($"EVENT: {st.Name} has PASSED");
        }

        // Sort by average (descending)
        students.Sort((a, b) => b.Average.CompareTo(a.Average));

        // Ranking with ties (dense ranking)
        int rank = 1;
        double previousAverage = -1;

        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].Average != previousAverage)
            {
                rank = i + 1;
                previousAverage = students[i].Average;
            }
            students[i].Rank = rank;
        }

        // Predicate → pass/fail
        Predicate<Student<int>> isPassed = s => s.Average >= 40;

        // Func → grade calculation
        Func<Student<int>, string> getGrade = s =>
        {
            if (s.Average >= 90) return "A+";
            if (s.Average >= 75) return "A";
            if (s.Average >= 60) return "B";
            if (s.Average >= 40) return "C";
            return "F";
        };

        // Delegate → reappear alert
        ReappearAlert reappearAlert = s =>
        {
            if (s.Average < 40)
                Console.WriteLine($"NOTICE: {s.Name} must reappear. Avg={s.Average}");
        };

        // Output
        foreach (var s in students)
        {
            Console.WriteLine(
                $"Rank {s.Rank} - {s.Name}\n" +
                $"S1={s.S1}, S2={s.S2}, Avg={s.Average}, Grade={getGrade(s)}\n"
            );

            if (!isPassed(s))
                reappearAlert(s);

            s.Evaluate();
        }
    }
}