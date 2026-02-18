using System; // Console

namespace ItTechGenie.M1.OOP.Q3
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Paste input lines, end with EMPTY line:");
            var lines = ConsoleInput.ReadLines();                               // read user input

            var engine = new RentalEngine();                                    // create rental engine
            engine.Run(lines);                                                  // process input
        }
    }

    public static class ConsoleInput
    {
        public static string[] ReadLines()
        {
            var list = new System.Collections.Generic.List<string>();           // store lines
            while (true)
            {
                var line = Console.ReadLine();                                  // read line
                if (string.IsNullOrWhiteSpace(line)) break;                     // stop
                list.Add(line);                                                 // add
            }
            return list.ToArray();                                              // return
        }
    }

    public interface IVehicle
    {
        string Registration { get; }                                            // unique id
        string Brand { get; }                                                   // brand
        decimal BaseRatePerDay { get; }                                         // base rate
        decimal CalculateRate(int days);                                        // pricing rule
    }

    public abstract class VehicleBase : IVehicle
    {
        public string Registration { get; }                                     // reg
        public string Brand { get; }                                            // brand
        public decimal BaseRatePerDay { get; }                                  // base rate

        protected VehicleBase(string reg, string brand, decimal rate)
        {
            Registration = reg;                                                 // assign
            Brand = brand;                                                      // assign
            BaseRatePerDay = rate;                                              // assign
        }

        public abstract decimal CalculateRate(int days);                         // derived pricing
    }

    public sealed class Car : VehicleBase
    {
        public Car(string reg, string brand, decimal rate) : base(reg, brand, rate) { } // base

        // ✅ TODO: Student must implement only this method
        public override decimal CalculateRate(int days)
        {
            // TODO:
            // - Car: total = BaseRatePerDay * days
            // - If days >= 3, apply 5% discount
            throw new NotImplementedException();
        }
    }

    public sealed class Bike : VehicleBase
    {
        public Bike(string reg, string brand, decimal rate) : base(reg, brand, rate) { } // base

        // ✅ TODO: Student must implement only this method
        public override decimal CalculateRate(int days)
        {
            // TODO:
            // - Bike: total = BaseRatePerDay * days
            // - Add fixed safety gear fee: 100 per rental (one-time)

            return (BaseRatePerDay* days) +100; 
        }
    }

    public class RentalEngine
    {
        private readonly System.Collections.Generic.Dictionary<string, IVehicle> _vehicles = new(); // inventory

        public void Run(string[] lines)
        {
            foreach (var raw in lines)                                          // each command
            {
                var cmd = Command.Parse(raw);                                   // parse

                if (cmd.Name == "VEHICLE_ADD")                                  // add vehicle
                {
                    var type = cmd.Get("type");                                 // Car/Bike
                    var reg = cmd.Get("reg");                                   // registration
                    var brand = cmd.Get("brand");                               // brand
                    var rate = decimal.Parse(cmd.Get("rate").Replace("₹","").Replace("/day","").Trim()); // parse rate roughly

                    IVehicle v = type.Equals("Car", StringComparison.OrdinalIgnoreCase)
                        ? new Car(reg, brand, rate)
                        : new Bike(reg, brand, rate);                           // create appropriate type

                    _vehicles[reg] = v;                                         // store
                }
                else if (cmd.Name == "RENT")                                    // rent
                {
                    var reg = cmd.Get("reg");                                   // vehicle reg
                    var customer = cmd.Get("customer");                         // customer (may contain #)
                    var days = int.Parse(cmd.Get("days"));                      // days
                    var note = cmd.Get("note");                                 // note

                    var total = CalculateBill(_vehicles[reg], days);            // ✅ TODO pricing
                    Console.WriteLine($"RENT OK | {reg} | {customer} | days={days} | total={total} | note={note}");
                }
            }
        }

        // ✅ TODO: Student must implement only this method
        public decimal CalculateBill(IVehicle vehicle, int days)
        {
            // TODO:
            // - validate days > 0
            // - call vehicle.CalculateRate(days)
            // - return total
            if(days<= 0) throw new ArgumentException("Days must be greater than zero.");
            return vehicle.CalculateRate(days);
        }
    }

    public class Command
    {
        public string Name { get; }
        private readonly System.Collections.Generic.Dictionary<string, string> _kv;

        private Command(string name, System.Collections.Generic.Dictionary<string, string> kv)
        {
            Name = name; _kv = kv;
        }

        public string Get(string key) => _kv.TryGetValue(key, out var v) ? v : "";

        public static Command Parse(string line)
        {
            var parts = line.Split('|');                                        // split
            var name = parts[0].Trim();                                         // name
            var kv = new System.Collections.Generic.Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            for (int i = 1; i < parts.Length; i++)
            {
                var p = parts[i];                                               // token
                var idx = p.IndexOf('=');                                       // '='
                if (idx <= 0) continue;                                         // skip
                var key = p.Substring(0, idx).Trim();                           // key
                var val = p.Substring(idx + 1).Trim().Trim('"');               // value
                kv[key] = val;                                                  // store
            }
            return new Command(name, kv);
        }
    }
}