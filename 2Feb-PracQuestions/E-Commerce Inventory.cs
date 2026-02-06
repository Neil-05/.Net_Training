using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }
}

class InventoryManager
{
    private List<Product> products = new List<Product>();
    private int counter = 1;

    public void AddProduct(string name, string category, double price, int stock)
    {
        string code = "P" + counter.ToString("D3");
        counter++;

        products.Add(new Product
        {
            ProductCode = code,
            ProductName = name,
            Category = category,
            Price = price,
            StockQuantity = stock
        });
    }

    public SortedDictionary<string, List<Product>> GroupProductsByCategory()
    {
        return new SortedDictionary<string, List<Product>>(
            products.GroupBy(p => p.Category)
                    .ToDictionary(g => g.Key, g => g.ToList()));
    }

    public bool UpdateStock(string code, int quantity)
    {
        var p = products.FirstOrDefault(x => x.ProductCode == code);

        if (p == null || p.StockQuantity < quantity)
            return false;

        p.StockQuantity -= quantity;
        return true;
    }

    public List<Product> GetProductsBelowPrice(double maxPrice)
    {
        return products.Where(p => p.Price <= maxPrice).ToList();
    }

    public Dictionary<string, int> GetCategoryStockSummary()
    {
        return products.GroupBy(p => p.Category)
                       .ToDictionary(g => g.Key,
                                     g => g.Sum(p => p.StockQuantity));
    }
}

class Program
{
    static void Main()
    {
        InventoryManager manager = new InventoryManager();

        manager.AddProduct("Laptop", "Electronics", 50000, 10);
        manager.AddProduct("Mobile", "Electronics", 20000, 20);
        manager.AddProduct("Shirt", "Clothing", 1500, 50);
        manager.AddProduct("Book", "Books", 500, 30);

        Console.WriteLine("Products By Category:");

        var grouped = manager.GroupProductsByCategory();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var p in g.Value)
                Console.WriteLine(p.ProductName + " - " + p.ProductCode);
        }

        manager.UpdateStock("P001", 2);

        Console.WriteLine("\nProducts Under 2000:");

        foreach (var p in manager.GetProductsBelowPrice(2000))
            Console.WriteLine(p.ProductName);

        Console.WriteLine("\nStock Summary:");

        var summary = manager.GetCategoryStockSummary();

        foreach (var s in summary)
            Console.WriteLine(s.Key + " : " + s.Value);
    }
}
