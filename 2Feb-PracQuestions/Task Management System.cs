using System;
using System.Collections.Generic;
using System.Linq;

class TaskItem
{
    public int TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public DateTime DueDate { get; set; }
    public string AssignedTo { get; set; }
}

class Project
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string ProjectManager { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}

class TaskManager
{
    private List<Project> projects = new List<Project>();
    private int pCounter = 1;
    private int tCounter = 1;

    public void CreateProject(string name, string manager,
                              DateTime start, DateTime end)
    {
        projects.Add(new Project
        {
            ProjectId = pCounter++,
            ProjectName = name,
            ProjectManager = manager,
            StartDate = start,
            EndDate = end
        });
    }

    public void AddTask(int pid, string title, string desc,
                        string priority, DateTime due, string assignee)
    {
        var p = projects.FirstOrDefault(x => x.ProjectId == pid);

        if (p == null) return;

        p.Tasks.Add(new TaskItem
        {
            TaskId = tCounter++,
            Title = title,
            Description = desc,
            Priority = priority,
            Status = "ToDo",
            DueDate = due,
            AssignedTo = assignee
        });
    }

    public Dictionary<string, List<TaskItem>> GroupTasksByPriority()
    {
        return projects.SelectMany(p => p.Tasks)
                       .GroupBy(t => t.Priority)
                       .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<TaskItem> GetOverdueTasks()
    {
        return projects.SelectMany(p => p.Tasks)
                       .Where(t => t.DueDate < DateTime.Today &&
                                   t.Status != "Completed")
                       .ToList();
    }

    public List<TaskItem> GetTasksByAssignee(string name)
    {
        return projects.SelectMany(p => p.Tasks)
                       .Where(t => t.AssignedTo == name).ToList();
    }
}

class Program
{
    static void Main()
    {
        TaskManager manager = new TaskManager();

        manager.CreateProject("Website", "Mukesh",
            DateTime.Today, DateTime.Today.AddMonths(3));

        manager.AddTask(1, "Design UI", "Create layout",
            "High", DateTime.Today.AddDays(5), "Amit");

        manager.AddTask(1, "Backend", "API work",
            "Medium", DateTime.Today.AddDays(10), "Ravi");

        Console.WriteLine("Tasks By Priority:");

        var grouped = manager.GroupTasksByPriority();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var t in g.Value)
                Console.WriteLine(t.Title);
        }

        Console.WriteLine("\nOverdue Tasks:");

        foreach (var t in manager.GetOverdueTasks())
            Console.WriteLine(t.Title);

        Console.WriteLine("\nTasks For Amit:");

        foreach (var t in manager.GetTasksByAssignee("Amit"))
            Console.WriteLine(t.Title);
    }
}
