using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public string Supplier { get; set; }
    public double UnitPrice { get; set; }
    public int CurrentStock { get; set; }
    public int MinimumStockLevel { get; set; }
}

class StockMovement
{
    public int MovementId { get; set; }
    public string ProductCode { get; set; }
    public DateTime MovementDate { get; set; }
    public string MovementType { get; set; }
    public int Quantity { get; set; }
    public string Reason { get; set; }
}

class InventoryManager
{
    private List<Product> products = new List<Product>();
    private List<StockMovement> movements = new List<StockMovement>();

    private int mCounter = 1;

    public void AddProduct(string code, string name, string category,
                           string supplier, double price,
                           int stock, int min)
    {
        products.Add(new Product
        {
            ProductCode = code,
            ProductName = name,
            Category = category,
            Supplier = supplier,
            UnitPrice = price,
            CurrentStock = stock,
            MinimumStockLevel = min
        });
    }

    public bool UpdateStock(string code, string type,
                            int qty, string reason)
    {
        var p = products.FirstOrDefault(x => x.ProductCode == code);

        if (p == null) return false;

        if (type == "Out" && p.CurrentStock < qty)
            return false;

        if (type == "In") p.CurrentStock += qty;
        else p.CurrentStock -= qty;

        movements.Add(new StockMovement
        {
            MovementId = mCounter++,
            ProductCode = code,
            MovementDate = DateTime.Now,
            MovementType = type,
            Quantity = qty,
            Reason = reason
        });

        return true;
    }

    public Dictionary<string, List<Product>> GroupProductsByCategory()
    {
        return products.GroupBy(p => p.Category)
                       .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Product> GetLowStockProducts()
    {
        return products.Where(p =>
            p.CurrentStock <= p.MinimumStockLevel).ToList();
    }

    public Dictionary<string, int> GetStockValueByCategory()
    {
        return products.GroupBy(p => p.Category)
                       .ToDictionary(g => g.Key,
                                     g => g.Sum(p =>
                                     (int)(p.UnitPrice * p.CurrentStock)));
    }
}

class Program
{
    static void Main()
    {
        InventoryManager manager = new InventoryManager();

        manager.AddProduct("P1", "Keyboard", "Electronics",
            "HP", 500, 20, 5);

        manager.AddProduct("P2", "Chair", "Furniture",
            "IKEA", 2000, 8, 3);

        manager.UpdateStock("P1", "Out", 17, "Sale");

        Console.WriteLine("Low Stock:");

        foreach (var p in manager.GetLowStockProducts())
            Console.WriteLine(p.ProductName);

        Console.WriteLine("\nStock Value:");

        var value = manager.GetStockValueByCategory();

        foreach (var v in value)
            Console.WriteLine(v.Key + " : " + v.Value);
    }
}
