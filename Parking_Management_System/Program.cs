using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Vehicle
{
    public string VehicleNumber { get; set; }
    public string OwnerName { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime ExitTime { get; set; }

    public abstract double CalculateFee();
}


public class Car : Vehicle
{
    public override double CalculateFee()
    {
        // TODO:
        // Fee = hours * 50
        double hours= (ExitTime-EntryTime).TotalHours;
        double Fee = hours *50;
        return Fee;
    }
}

public class Bike : Vehicle
{
    public override double CalculateFee()
    {
        // TODO:
        // Fee = hours * 30
        double hours= (ExitTime-EntryTime).TotalHours;
        double Fee=hours*30;
        return Fee;
    }
}

public class Truck : Vehicle
{
    public override double CalculateFee()
    {
        // TODO:
        // Fee = hours * 100
        double hours= (ExitTime-EntryTime).TotalHours;
        double Fee=hours*100;

        return Fee;
    }
}


public class VehicleNotFoundException : Exception
{
    public VehicleNotFoundException(string message) : base(message)
    {
    }
}


public interface IParkingRepository<T> where T : Vehicle
{
    void Add(T vehicle);
    void Remove(string vehicleNumber);
    List<T> GetAll();
    T FindByNumber(string vehicleNumber);
}


public class ParkingRepository<T> : IParkingRepository<T> where T : Vehicle
{
    private List<T> vehicles = new List<T>();

    public void Add(T vehicle)
    {
        // TODO:
        // Add vehicle
        // Prevent duplicate VehicleNumber
        if(vehicles.Any(v=>v.VehicleNumber == vehicle.VehicleNumber))
        throw new Exception("Duplicate Vehicle Number");
        vehicles.Add(vehicle);
        
    }

    public void Remove(string vehicleNumber)
    {
        // TODO:
        // Remove vehicle
        // If not found → throw VehicleNotFoundException
        var vehicle= vehicles.FirstOrDefault(v=>v.VehicleNumber == vehicleNumber);
        if(vehicle == null) throw new VehicleNotFoundException($"Vehicle with number {vehicleNumber} not found");
        vehicles.Remove(vehicle);
    }

    public List<T> GetAll()
    {
        return vehicles;
    }

    public T FindByNumber(string vehicleNumber)
    {
        // TODO:
        // Return vehicle
        // If not found → throw VehicleNotFoundException
        var number = vehicles.FirstOrDefault(v=> v.VehicleNumber == vehicleNumber);
        if(number == null) throw new VehicleNotFoundException($"Vehicle with number {vehicleNumber} not found");
        return number;
    }
}


public delegate double FeeCalculatorDelegate(double baseFee);


public class ParkingManager
{
    public event Action<string> OnVehicleExited;

    public void ExitVehicle(Vehicle vehicle, FeeCalculatorDelegate calculator)
    {
        // TODO:
        // 1. Set ExitTime = DateTime.Now
        // 2. Calculate base fee using CalculateFee()
        // 3. Apply delegate for extra charges
        // 4. Trigger event with message
        vehicle.ExitTime=DateTime.Now;
        double basefee=vehicle.CalculateFee();
        double total= calculator(basefee);
        OnVehicleExited?.Invoke($"Vehicle {vehicle.VehicleNumber} exited. Total fee: {total}");
    }
}


public class Program
{
    public static void Main()
    {
        ParkingRepository<Vehicle> repo = new ParkingRepository<Vehicle>();
        ParkingManager manager = new ParkingManager();

        manager.OnVehicleExited += message =>
        {
            Console.WriteLine(message);
        };

        // Add vehicles
        repo.Add(new Car { VehicleNumber = "MH01", OwnerName = "Neil", EntryTime = DateTime.Now.AddHours(-3) });
        repo.Add(new Bike { VehicleNumber = "MH02", OwnerName = "Rahul", EntryTime = DateTime.Now.AddHours(-1) });

        try
        {
            var vehicle = repo.FindByNumber("MH01");

            // Example delegate: Add 10% weekend charge
            FeeCalculatorDelegate weekendCharge = (fee) => fee * 1.10;

            manager.ExitVehicle(vehicle, weekendCharge);
        }
        catch (VehicleNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // TODO: LINQ Queries

        // 1. Get vehicles parked more than 2 hours
        // 2. Get highest paying vehicle
        // 3. Group vehicles by type
        var longpark=repo.GetAll().Where(v=>(v.EntryTime-DateTime.Now).TotalHours>2);
        foreach(var vehicle in longpark)
        {
            Console.WriteLine($"Vehicle {vehicle.VehicleNumber} parked for more than 2 hours");
        }

        var highest= repo.GetAll().OrderByDescending(v=>v.CalculateFee()).FirstOrDefault();
        Console.WriteLine($"Highest paying vehicle: {highest.VehicleNumber} with fee {highest.CalculateFee()}");

        var group=repo.GetAll().GroupBy(v=>v.GetType().Name);
        foreach(var g in group)        {
            Console.WriteLine($"Vehicle Type: {g.Key}, Count: {g.Count()}");
    }
}
}