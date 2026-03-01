using System;
using System.Collections.Generic;
using System.Linq;

class Event
{
    public int EventId { get; set; }
    public string EventName { get; set; }
    public string EventType { get; set; }
    public DateTime EventDate { get; set; }
    public string Venue { get; set; }
    public int TotalCapacity { get; set; }
    public int TicketsSold { get; set; }
    public double TicketPrice { get; set; }
}

class Attendee
{
    public int AttendeeId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<int> RegisteredEvents { get; set; }
        = new List<int>();
}

class Ticket
{
    public string TicketNumber { get; set; }
    public int EventId { get; set; }
    public int AttendeeId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string SeatNumber { get; set; }
}

class EventManager
{
    private List<Event> events = new List<Event>();
    private List<Attendee> attendees = new List<Attendee>();
    private List<Ticket> tickets = new List<Ticket>();

    private int eCounter = 1;
    private int aCounter = 1;
    private int tCounter = 1;

    public void CreateEvent(string name, string type,
                            DateTime date, string venue,
                            int capacity, double price)
    {
        events.Add(new Event
        {
            EventId = eCounter++,
            EventName = name,
            EventType = type,
            EventDate = date,
            Venue = venue,
            TotalCapacity = capacity,
            TicketsSold = 0,
            TicketPrice = price
        });
    }

    public void AddAttendee(string name, string email, string phone)
    {
        attendees.Add(new Attendee
        {
            AttendeeId = aCounter++,
            Name = name,
            Email = email,
            Phone = phone
        });
    }

    public bool BookTicket(int eid, int aid, string seat)
    {
        var ev = events.FirstOrDefault(e => e.EventId == eid);
        var at = attendees.FirstOrDefault(a => a.AttendeeId == aid);

        if (ev == null || at == null) return false;

        if (ev.TicketsSold >= ev.TotalCapacity)
            return false;

        tickets.Add(new Ticket
        {
            TicketNumber = "T" + tCounter++,
            EventId = eid,
            AttendeeId = aid,
            PurchaseDate = DateTime.Now,
            SeatNumber = seat
        });

        ev.TicketsSold++;
        at.RegisteredEvents.Add(eid);

        return true;
    }

    public Dictionary<string, List<Event>> GroupEventsByType()
    {
        return events.GroupBy(e => e.EventType)
                     .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Event> GetUpcomingEvents(int days)
    {
        DateTime end = DateTime.Today.AddDays(days);

        return events.Where(e =>
            e.EventDate >= DateTime.Today &&
            e.EventDate <= end).ToList();
    }

    public double CalculateEventRevenue(int id)
    {
        var ev = events.FirstOrDefault(e => e.EventId == id);

        if (ev == null) return 0;

        return ev.TicketsSold * ev.TicketPrice;
    }
}

class Program
{
    static void Main()
    {
        EventManager manager = new EventManager();

        manager.CreateEvent("TechConf", "Conference",
            DateTime.Today.AddDays(10), "Delhi", 200, 1500);

        manager.CreateEvent("MusicFest", "Concert",
            DateTime.Today.AddDays(20), "Mumbai", 500, 2500);

        manager.AddAttendee("Mukesh", "m@gmail.com", "9999");
        manager.AddAttendee("Amit", "a@gmail.com", "8888");

        manager.BookTicket(1, 1, "A1");
        manager.BookTicket(2, 2, "B5");

        Console.WriteLine("Events By Type:");

        var grouped = manager.GroupEventsByType();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var e in g.Value)
                Console.WriteLine(e.EventName);
        }

        Console.WriteLine("\nUpcoming Events:");

        foreach (var e in manager.GetUpcomingEvents(30))
            Console.WriteLine(e.EventName);

        Console.WriteLine("\nRevenue TechConf: " +
            manager.CalculateEventRevenue(1));
    }
}
