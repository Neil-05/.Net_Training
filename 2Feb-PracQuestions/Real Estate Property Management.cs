using System;
using System.Collections.Generic;
using System.Linq;

class Property
{
    public string PropertyId { get; set; }
    public string Address { get; set; }
    public string PropertyType { get; set; }
    public int Bedrooms { get; set; }
    public double AreaSqFt { get; set; }
    public double Price { get; set; }
    public string Status { get; set; }
    public string Owner { get; set; }
}

class Client
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }
    public string ClientType { get; set; }
    public double Budget { get; set; }
    public List<string> Requirements { get; set; }
        = new List<string>();
}

class Viewing
{
    public int ViewingId { get; set; }
    public string PropertyId { get; set; }
    public int ClientId { get; set; }
    public DateTime ViewingDate { get; set; }
    public string Feedback { get; set; }
}

class RealEstateManager
{
    private List<Property> properties = new List<Property>();
    private List<Client> clients = new List<Client>();
    private List<Viewing> viewings = new List<Viewing>();

    private int pCounter = 1;
    private int cCounter = 1;
    private int vCounter = 1;

    public void AddProperty(string address, string type,
                            int beds, double area,
                            double price, string owner)
    {
        properties.Add(new Property
        {
            PropertyId = "PR" + pCounter++,
            Address = address,
            PropertyType = type,
            Bedrooms = beds,
            AreaSqFt = area,
            Price = price,
            Status = "Available",
            Owner = owner
        });
    }

    public void AddClient(string name, string contact,
                          string type, double budget,
                          List<string> req)
    {
        clients.Add(new Client
        {
            ClientId = cCounter++,
            Name = name,
            Contact = contact,
            ClientType = type,
            Budget = budget,
            Requirements = req
        });
    }

    public bool ScheduleViewing(string pid, int cid, DateTime date)
    {
        var p = properties.FirstOrDefault(x => x.PropertyId == pid);
        var c = clients.FirstOrDefault(x => x.ClientId == cid);

        if (p == null || c == null) return false;

        viewings.Add(new Viewing
        {
            ViewingId = vCounter++,
            PropertyId = pid,
            ClientId = cid,
            ViewingDate = date
        });

        return true;
    }

    public Dictionary<string, List<Property>> GroupPropertiesByType()
    {
        return properties.GroupBy(p => p.PropertyType)
                         .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Property> GetPropertiesInBudget(double min, double max)
    {
        return properties.Where(p =>
            p.Price >= min && p.Price <= max).ToList();
    }
}

class Program
{
    static void Main()
    {
        RealEstateManager manager = new RealEstateManager();

        manager.AddProperty("Delhi", "Apartment",
            3, 1200, 5000000, "Sharma");

        manager.AddProperty("Gurgaon", "Villa",
            4, 2500, 12000000, "Verma");

        manager.AddClient("Mukesh", "9999",
            "Buyer", 6000000,
            new List<string> { "3BHK" });

        manager.ScheduleViewing("PR1", 1,
            DateTime.Today.AddDays(2));

        Console.WriteLine("Properties By Type:");

        var grouped = manager.GroupPropertiesByType();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var p in g.Value)
                Console.WriteLine(p.Address);
        }

        Console.WriteLine("\nIn Budget:");

        foreach (var p in manager.GetPropertiesInBudget(4000000, 7000000))
            Console.WriteLine(p.Address);
    }
}
