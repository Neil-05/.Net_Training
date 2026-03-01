using System;
using System.Collections.Generic;
using System.Linq;

class Package
{
    public string TrackingNumber { get; set; }
    public string SenderName { get; set; }
    public string ReceiverName { get; set; }
    public string DestinationAddress { get; set; }
    public double Weight { get; set; }
    public string PackageType { get; set; }
    public double ShippingCost { get; set; }
}

class DeliveryStatus
{
    public string TrackingNumber { get; set; }
    public List<string> Checkpoints { get; set; } = new List<string>();
    public string CurrentStatus { get; set; }
    public DateTime EstimatedDelivery { get; set; }
    public DateTime? ActualDelivery { get; set; }
}

class CourierManager
{
    private List<Package> packages = new List<Package>();
    private List<DeliveryStatus> statuses = new List<DeliveryStatus>();
    private int counter = 1;

    public void AddPackage(string sender, string receiver,
                           string address, double weight,
                           string type, double cost)
    {
        string track = "TR" + counter++.ToString("D4");

        packages.Add(new Package
        {
            TrackingNumber = track,
            SenderName = sender,
            ReceiverName = receiver,
            DestinationAddress = address,
            Weight = weight,
            PackageType = type,
            ShippingCost = cost
        });

        statuses.Add(new DeliveryStatus
        {
            TrackingNumber = track,
            CurrentStatus = "Dispatched",
            EstimatedDelivery = DateTime.Today.AddDays(5)
        });
    }

    public bool UpdateStatus(string track, string status, string checkpoint)
    {
        var s = statuses.FirstOrDefault(x => x.TrackingNumber == track);

        if (s == null) return false;

        s.CurrentStatus = status;
        s.Checkpoints.Add(checkpoint);

        if (status == "Delivered")
            s.ActualDelivery = DateTime.Now;

        return true;
    }

    public Dictionary<string, List<Package>> GroupPackagesByType()
    {
        return packages.GroupBy(p => p.PackageType)
                       .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Package> GetPackagesByDestination(string city)
    {
        return packages.Where(p =>
            p.DestinationAddress.Contains(city)).ToList();
    }

    public List<Package> GetDelayedPackages()
    {
        return packages.Where(p =>
        {
            var s = statuses.First(x => x.TrackingNumber == p.TrackingNumber);

            return s.ActualDelivery == null &&
                   DateTime.Today > s.EstimatedDelivery;
        }).ToList();
    }
}

class Program
{
    static void Main()
    {
        CourierManager manager = new CourierManager();

        manager.AddPackage("Mukesh", "Amit",
            "Delhi, India", 2.5, "Parcel", 300);

        manager.AddPackage("Ravi", "Suresh",
            "Mumbai, India", 1.2, "Document", 150);

        manager.UpdateStatus("TR0001", "InTransit", "Delhi Hub");
        manager.UpdateStatus("TR0001", "Delivered", "Mumbai Hub");

        Console.WriteLine("Packages By Type:");

        var grouped = manager.GroupPackagesByType();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var p in g.Value)
                Console.WriteLine(p.TrackingNumber);
        }

        Console.WriteLine("\nPackages To Delhi:");

        foreach (var p in manager.GetPackagesByDestination("Delhi"))
            Console.WriteLine(p.TrackingNumber);
    }
}
