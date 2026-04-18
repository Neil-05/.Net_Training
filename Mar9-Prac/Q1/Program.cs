using System; // Console
using System.Collections.Generic; // List<T>, IReadOnlyList<T>

namespace ItTechGenie.M1.GenericsDelegates.Q2
{
    public class Program
    {
        public static void Main()
        {
            var repo = new InMemoryRepository<Product>();    // repository for Product
            repo.Add(new Product(1, "Mouse", 699));          // add item
            repo.Add(new Product(2, "Keyboard", 1499));      // add item

            foreach (var p in repo.GetAll())                 // iterate all products
            {
                Console.WriteLine($"{p.Id} - {p.Name} - {p.Price}"); // print each product
            }
        }
    }

    public record Product(int Id, string Name, int Price);   // simple model

    public class InMemoryRepository<T>
    {
        private readonly List<T> _items = new();             // internal storage

        // ✅ TODO: Student must implement only this method
        public void Add(T item)
        {
            // TODO: Write your code here
           _items.Add(item);          // remove after implementing
        }

        // ✅ TODO: Student must implement only this method
        public IReadOnlyList<T> GetAll()
        {
            // TODO: Write your code here
            return _items;  // remove after implementing
        }
    }
}