using System;
using System.Collections.Generic;
using System.Linq;

class Flight
{
    public string FlightNumber { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int TotalSeats { get; set; }
    public int AvailableSeats { get; set; }
    public double TicketPrice { get; set; }
}

class Booking
{
    public string BookingId { get; set; }
    public string FlightNumber { get; set; }
    public string PassengerName { get; set; }
    public int SeatsBooked { get; set; }
    public double TotalFare { get; set; }
    public string SeatClass { get; set; }
}

class AirlineManager
{
    private List<Flight> flights = new List<Flight>();
    private List<Booking> bookings = new List<Booking>();
    private int bCounter = 1;

    public void AddFlight(string no, string from, string to,
                          DateTime dep, DateTime arr,
                          int seats, double price)
    {
        flights.Add(new Flight
        {
            FlightNumber = no,
            Origin = from,
            Destination = to,
            DepartureTime = dep,
            ArrivalTime = arr,
            TotalSeats = seats,
            AvailableSeats = seats,
            TicketPrice = price
        });
    }

    public bool BookFlight(string no, string name,
                           int seats, string seatClass)
    {
        var f = flights.FirstOrDefault(x => x.FlightNumber == no);

        if (f == null || f.AvailableSeats < seats) return false;

        double fare = seats * f.TicketPrice;

        bookings.Add(new Booking
        {
            BookingId = "B" + bCounter++,
            FlightNumber = no,
            PassengerName = name,
            SeatsBooked = seats,
            TotalFare = fare,
            SeatClass = seatClass
        });

        f.AvailableSeats -= seats;

        return true;
    }

    public Dictionary<string, List<Flight>> GroupFlightsByDestination()
    {
        return flights.GroupBy(f => f.Destination)
                      .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Flight> SearchFlights(string from, string to, DateTime date)
    {
        return flights.Where(f =>
            f.Origin == from &&
            f.Destination == to &&
            f.DepartureTime.Date == date.Date).ToList();
    }

    public double CalculateTotalRevenue(string flightNo)
    {
        return bookings.Where(b => b.FlightNumber == flightNo)
                       .Sum(b => b.TotalFare);
    }
}

class Program
{
    static void Main()
    {
        AirlineManager manager = new AirlineManager();

        manager.AddFlight("AI101", "Delhi", "Mumbai",
            DateTime.Today.AddHours(9),
            DateTime.Today.AddHours(11), 100, 3500);

        manager.AddFlight("AI102", "Delhi", "Pune",
            DateTime.Today.AddHours(14),
            DateTime.Today.AddHours(16), 80, 3000);

        manager.BookFlight("AI101", "Mukesh", 2, "Economy");

        Console.WriteLine("Flights By Destination:");

        var grouped = manager.GroupFlightsByDestination();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var f in g.Value)
                Console.WriteLine(f.FlightNumber);
        }

        Console.WriteLine("\nSearch Result:");

        var list = manager.SearchFlights("Delhi", "Mumbai", DateTime.Today);

        foreach (var f in list)
            Console.WriteLine(f.FlightNumber);

        Console.WriteLine("\nRevenue AI101: " +
            manager.CalculateTotalRevenue("AI101"));
    }
}
