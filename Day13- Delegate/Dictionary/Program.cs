class Program
{
    static void Main()
    {
        var salaries = new Dictionary<int, int>
        {
            {1, 20000},
            {4, 40000},
            {5, 15000}
        };

        var ids = new List<int> { 1, 4, 5 };

        int totalSalary = ids.Sum(id => salaries[id]);

        Console.WriteLine(totalSalary);
    }
}
