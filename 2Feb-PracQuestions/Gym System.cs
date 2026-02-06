using System;
using System.Collections.Generic;
using System.Linq;

class Member
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public string MembershipType { get; set; }
    public DateTime JoinDate { get; set; }
    public DateTime ExpiryDate { get; set; }
}

class FitnessClass
{
    public string ClassName { get; set; }
    public string Instructor { get; set; }
    public DateTime Schedule { get; set; }
    public int MaxParticipants { get; set; }
    public List<int> RegisteredMembers { get; set; }
        = new List<int>();
}

class GymManager
{
    private List<Member> members = new List<Member>();
    private List<FitnessClass> classes = new List<FitnessClass>();
    private int counter = 1;

    public void AddMember(string name, string type, int months)
    {
        members.Add(new Member
        {
            MemberId = counter++,
            Name = name,
            MembershipType = type,
            JoinDate = DateTime.Today,
            ExpiryDate = DateTime.Today.AddMonths(months)
        });
    }

    public void AddClass(string name, string instructor,
                         DateTime schedule, int max)
    {
        classes.Add(new FitnessClass
        {
            ClassName = name,
            Instructor = instructor,
            Schedule = schedule,
            MaxParticipants = max
        });
    }

    public bool RegisterForClass(int id, string className)
    {
        var c = classes.FirstOrDefault(x => x.ClassName == className);
        var m = members.FirstOrDefault(x => x.MemberId == id);

        if (c == null || m == null) return false;

        if (c.RegisteredMembers.Count >= c.MaxParticipants)
            return false;

        if (!c.RegisteredMembers.Contains(id))
            c.RegisteredMembers.Add(id);

        return true;
    }

    public Dictionary<string, List<Member>> GroupMembersByMembershipType()
    {
        return members.GroupBy(m => m.MembershipType)
                      .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<FitnessClass> GetUpcomingClasses()
    {
        DateTime end = DateTime.Today.AddDays(7);

        return classes.Where(c =>
            c.Schedule >= DateTime.Today &&
            c.Schedule <= end).ToList();
    }
}

class Program
{
    static void Main()
    {
        GymManager manager = new GymManager();

        manager.AddMember("Mukesh", "Premium", 6);
        manager.AddMember("Amit", "Basic", 3);
        manager.AddMember("Ravi", "Platinum", 12);

        manager.AddClass("Yoga", "Ramesh",
            DateTime.Today.AddDays(2), 20);

        manager.AddClass("Zumba", "Sita",
            DateTime.Today.AddDays(5), 15);

        manager.RegisterForClass(1, "Yoga");
        manager.RegisterForClass(2, "Yoga");

        Console.WriteLine("Members By Type:");

        var grouped = manager.GroupMembersByMembershipType();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var m in g.Value)
                Console.WriteLine(m.Name);
        }

        Console.WriteLine("\nUpcoming Classes:");

        foreach (var c in manager.GetUpcomingClasses())
            Console.WriteLine(c.ClassName + " - " + c.Schedule);
    }
}
