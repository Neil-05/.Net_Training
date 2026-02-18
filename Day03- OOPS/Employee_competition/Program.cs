using System;

class Employee
{
    private int empId;
    private string name;

    public Employee(int empId, string name)
    {
        this.empId =empId;
        this.name =name;
    }

    public int EmpId =>empId;
    public string Name =>name;

    public void DisplayEmployee()
    {
        Console.WriteLine("Employee ID: " + empId);
        Console.WriteLine("Employee Name: " + name);
    }
}

class Competition
{
    private string competitionName;
    private int score;

    public Competition(string competitionName, int score)
    {
        this.competitionName = competitionName;
        this.score = score;
    }

    public int Score => score;

    public void DisplayCompetition()
    {
        Console.WriteLine("Competition Name: " + competitionName);
        Console.WriteLine("Score: " + score);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Employee[] employees =
        {
            new Employee(101, "Neil"),
            new Employee(102, "Neymar"),
            new Employee(103, "Mbappe")
        };
        Competition[] competitions =
        {
            new Competition("Coding Contest", 68),
            new Competition("Coding Contest", 85),
            new Competition("Coding Contest", 74)
        };
        int winnerIndex = 0;
        for (int i = 1; i < competitions.Length; i++)
        {
            if (competitions[i].Score > competitions[winnerIndex].Score)
                winnerIndex = i;
        }
        Console.WriteLine("\nWinner Details:");
        employees[winnerIndex].DisplayEmployee();
        competitions[winnerIndex].DisplayCompetition();
    }
}
