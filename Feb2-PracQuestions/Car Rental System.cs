using System;
using System.Collections.Generic;
using System.Linq;

class RentalCar
{
    public string LicensePlate { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string CarType { get; set; }
    public bool IsAvailable { get; set; }
    public double DailyRate { get; set; }
}

class Rental
{
    public int RentalId { get; set; }
    public string LicensePlate { get; set; }
    public string CustomerName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double TotalCost { get; set; }
}

class RentalManager
{
    private List<RentalCar> cars = new List<RentalCar>();
    private List<Rental> rentals = new List<Rental>();
    private int counter = 1;

    public void AddCar(string license, string make,
                       string model, string type, double rate)
    {
        cars.Add(new RentalCar
        {
            LicensePlate = license,
            Make = make,
            Model = model,
            CarType = type,
            DailyRate = rate,
            IsAvailable = true
        });
    }

    public bool RentCar(string license, string customer,
                        DateTime start, int days)
    {
        var car = cars.FirstOrDefault(c =>
            c.LicensePlate == license && c.IsAvailable);

        if (car == null) return false;

        double cost = car.DailyRate * days;

        rentals.Add(new Rental
        {
            RentalId = counter++,
            LicensePlate = license,
            CustomerName = customer,
            StartDate = start,
            EndDate = start.AddDays(days),
            TotalCost = cost
        });

        car.IsAvailable = false;

        return true;
    }

    public Dictionary<string, List<RentalCar>> GroupCarsByType()
    {
        return cars.Where(c => c.IsAvailable)
                   .GroupBy(c => c.CarType)
                   .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Rental> GetActiveRentals()
    {
        DateTime now = DateTime.Today;

        return rentals.Where(r =>
            r.StartDate <= now && r.EndDate >= now).ToList();
    }

    public double CalculateTotalRentalRevenue()
    {
        return rentals.Sum(r => r.TotalCost);
    }
}

class Program
{
    static void Main()
    {
        RentalManager manager = new RentalManager();

        manager.AddCar("HR01A1234", "Honda", "City", "Sedan", 2000);
        manager.AddCar("DL02B4567", "Toyota", "Innova", "SUV", 3000);
        manager.AddCar("PB03C7890", "Maruti", "Eeco", "Van", 1500);

        manager.RentCar("HR01A1234", "Mukesh",
            DateTime.Today, 3);

        Console.WriteLine("Available Cars By Type:");

        var grouped = manager.GroupCarsByType();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var c in g.Value)
                Console.WriteLine(c.LicensePlate);
        }

        Console.WriteLine("\nActive Rentals:");

        foreach (var r in manager.GetActiveRentals())
            Console.WriteLine(r.CustomerName + " - " + r.LicensePlate);

        Console.WriteLine("\nTotal Revenue: " +
            manager.CalculateTotalRentalRevenue());
    }
}
