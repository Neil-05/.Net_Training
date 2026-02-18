using System; // Console

namespace ItTechGenie.M1.OOP.Q2
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Paste input lines, end with EMPTY line:");
            var lines = ConsoleInput.ReadLines();                               // read multi-line input

            var payroll = new PayrollEngine();                                  // engine
            payroll.Run(lines);                                                 // execute
        }
    }

    public static class ConsoleInput
    {
        public static string[] ReadLines()
        {
            var list = new System.Collections.Generic.List<string>();           // collect lines
            while (true)
            {
                var line = Console.ReadLine();                                  // read
                if (string.IsNullOrWhiteSpace(line)) break;                     // stop
                list.Add(line);                                                 // store
            }
            return list.ToArray();                                              // return
        }
    }

    public class PayrollEngine
    {
        private readonly System.Collections.Generic.List<Employee> _employees = new(); // employee list

        public void Run(string[] lines)
        {
            foreach (var raw in lines)                                          // for each command
            {
                var cmd = Command.Parse(raw);                                   // parse

                if (cmd.Name == "EMP_ADD")                                      // add employee
                {
                    var emp = EmployeeFactory.Create(cmd);                       // ✅ TODO factory
                    _employees.Add(emp);                                        // store
                }
                else if (cmd.Name == "PAYROLL")                                 // run payroll
                {
                    Console.WriteLine("---- PAYROLL RUN ----");                 // header
                    foreach (var e in _employees)                               // for each employee
                    {
                        var salary = e.CalculateSalary();                       // ✅ polymorphic call
                        Console.WriteLine($"{e.Id} | {e.Name} | {e.Role} | Salary={salary}"); // print
                    }
                }
            }
        }
    }

    public abstract class Employee
    {
        public string Id { get; }                                               // employee id
        public string Name { get; }                                             // employee name
        public string Role { get; }                                             // role
        public decimal BasePay { get; }                                         // base pay
        public string Extra { get; }                                            // extra info (may contain spaces)

        protected Employee(string id, string name, string role, decimal basePay, string extra)
        {
            Id = id;                                                           // assign
            Name = name;                                                       // assign
            Role = role;                                                       // assign
            BasePay = basePay;                                                 // assign
            Extra = extra;                                                     // assign
        }

        public abstract decimal CalculateSalary();                               // polymorphic salary calc
    }

    public sealed class Developer : Employee
    {
        public Developer(string id, string name, decimal basePay, string extra)
            : base(id, name, "Developer", basePay, extra) { }                   // call base

        // ✅ TODO: Student must implement only this method
        public override decimal CalculateSalary()
        {
            // TODO:
            // - Developer: salary = BasePay + (BasePay * 0.10m) as skill bonus
            // - Extra text may include skill info, but you don't need to parse it
            decimal salary= BasePay +(BasePay *0.10m);
            return salary;
        }
    }

    public sealed class Manager : Employee
    {
        public Manager(string id, string name, decimal basePay, string extra)
            : base(id, name, "Manager", basePay, extra) { }                     // call base

        // ✅ TODO: Student must implement only this method
        public override decimal CalculateSalary()
        {
            // TODO:
            // - Manager: salary = BasePay + 15000 allowance + (BasePay * 0.05m) performance bonus
            return BasePay + 15000 + (BasePay * 0.05m);
        }
    }

    public static class EmployeeFactory
    {
        // ✅ TODO: Student must implement only this method
        public static Employee Create(Command cmd)
        {
            // TODO:
            // - read role, id, name, base, extra
            // - create Developer or Manager based on role (case-insensitive)
            // - throw meaningful exception for unknown role

            string role= cmd.Get("role").Trim().ToLower();
            string id = cmd.Get("id").Trim();
            string name = cmd.Get("name").Trim();
            decimal basePay = decimal.Parse(cmd.Get("base").Trim());
            string extra= cmd.Get("extra").Trim();
            if(role == "developer")
            {
                return new Developer(id, name, basePay, extra);
            }
            else if(role == "manager")
            {
                return new Manager(id, name, basePay, extra);
            }
            else
            {
                throw new ArgumentException("Unknown role");
            }
        }
    }

    public class Command
    {
        public string Name { get; }                                             // cmd name
        private readonly System.Collections.Generic.Dictionary<string, string> _kv; // parameters

        private Command(string name, System.Collections.Generic.Dictionary<string, string> kv)
        {
            Name = name;                                                        // assign
            _kv = kv;                                                           // assign
        }

        public string Get(string key) => _kv.TryGetValue(key, out var v) ? v : ""; // safe get

        public static Command Parse(string line)
        {
            var parts = line.Split('|');                                        // split
            var name = parts[0].Trim();                                         // cmd
            var kv = new System.Collections.Generic.Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            for (int i = 1; i < parts.Length; i++)                              // read tokens
            {
                var p = parts[i];                                               // token
                var idx = p.IndexOf('=');                                       // find '='
                if (idx <= 0) continue;                                         // skip
                var key = p.Substring(0, idx).Trim();                           // key
                var val = p.Substring(idx + 1).Trim().Trim('"');               // value without quotes
                kv[key] = val;                                                  // store
            }

            return new Command(name, kv);                                       // build
        }
    }
}