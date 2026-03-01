using System;
using System.Collections.Generic;
using System.Linq;

class MovieScreening
{
    public string MovieTitle { get; set; }
    public DateTime ShowTime { get; set; }
    public string ScreenNumber { get; set; }
    public int TotalSeats { get; set; }
    public int BookedSeats { get; set; }
    public double TicketPrice { get; set; }
}

class TheaterManager
{
    private List<MovieScreening> screenings = new List<MovieScreening>();

    public void AddScreening(string title, DateTime time, string screen, int seats, double price)
    {
        screenings.Add(new MovieScreening
        {
            MovieTitle = title,
            ShowTime = time,
            ScreenNumber = screen,
            TotalSeats = seats,
            TicketPrice = price,
            BookedSeats = 0
        });
    }

    public bool BookTickets(string title, DateTime time, int tickets)
    {
        var s = screenings.FirstOrDefault(x =>
            x.MovieTitle == title && x.ShowTime == time);

        if (s == null) return false;

        if (s.TotalSeats - s.BookedSeats < tickets)
            return false;

        s.BookedSeats += tickets;
        return true;
    }

    public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
    {
        return screenings.GroupBy(s => s.MovieTitle)
                         .ToDictionary(g => g.Key, g => g.ToList());
    }

    public double CalculateTotalRevenue()
    {
        return screenings.Sum(s => s.BookedSeats * s.TicketPrice);
    }

    public List<MovieScreening> GetAvailableScreenings(int minSeats)
    {
        return screenings.Where(s =>
            s.TotalSeats - s.BookedSeats >= minSeats).ToList();
    }
}

class Program
{
    static void Main()
    {
        TheaterManager manager = new TheaterManager();

        manager.AddScreening("Avengers",
            DateTime.Today.AddHours(10), "S1", 100, 250);

        manager.AddScreening("Avengers",
            DateTime.Today.AddHours(15), "S2", 80, 220);

        manager.AddScreening("Batman",
            DateTime.Today.AddHours(12), "S3", 70, 200);

        manager.BookTickets("Avengers",
            DateTime.Today.AddHours(10), 20);

        Console.WriteLine("Screenings By Movie:");

        var grouped = manager.GroupScreeningsByMovie();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var s in g.Value)
                Console.WriteLine(s.ShowTime + " - " + s.ScreenNumber);
        }

        Console.WriteLine("\nTotal Revenue: " +
            manager.CalculateTotalRevenue());

        Console.WriteLine("\nAvailable Screenings (50+ seats):");

        foreach (var s in manager.GetAvailableScreenings(50))
            Console.WriteLine(s.MovieTitle + " " + s.ShowTime);
    }
}
