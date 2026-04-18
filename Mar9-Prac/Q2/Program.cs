using System; // Console
using System.Collections.Generic; // Dictionary<K,V>

namespace ItTechGenie.M1.GenericsDelegates.Q3
{
    public class Program
    {
        public static void Main()
        {
            var cache = new SimpleCache<Product>();               // cache stores Product (class)
            cache.Put("P100", new Product("P100", "Pen"));        // add to cache

            if (cache.TryGet("P100", out var found))              // attempt read
            {
                Console.WriteLine($"Found: {found.Code} - {found.Name}"); // print
            }
        }
    }

    public class Product
    {
        public string Code { get; }                               // product code
        public string Name { get; }                               // product name

        public Product(string code, string name)
        {
            Code = code;                                          // assign
            Name = name;                                          // assign
        }
    }

    // Note: `where T : class` means only reference types are allowed here.
    public class SimpleCache<T> where T : class
    {
        private readonly Dictionary<string, T> _store = new();    // key-value store

        // ✅ TODO: Student must implement only this method
        public void Put(string key, T value)
        {
            // TODO: Write your code here
           
           _store[key]= value;              // remove after implementing
        }

        // ✅ TODO: Student must implement only this method
        public bool TryGet(string key, out T? value)
        {
            value = null;                                         // default output
            return _store.TryGetValue(key,out value);
            
                             // remove after implementing
        }
    }
}