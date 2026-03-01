using System;
using System.Collections.Generic;
using System.Linq;

class MenuItem
{
    public string ItemName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public bool IsVegetarian { get; set; }
}

class MenuManager
{
    private List<MenuItem> items = new List<MenuItem>();

    public void AddMenuItem(string name, string category, double price, bool isVeg)
    {
        if (price <= 0) return;

        items.Add(new MenuItem
        {
            ItemName = name,
            Category = category,
            Price = price,
            IsVegetarian = isVeg
        });
    }

    public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
    {
        return items.GroupBy(i => i.Category)
                    .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<MenuItem> GetVegetarianItems()
    {
        return items.Where(i => i.IsVegetarian).ToList();
    }

    public double CalculateAveragePriceByCategory(string category)
    {
        var list = items.Where(i => i.Category == category).ToList();

        if (list.Count == 0) return 0;

        return list.Average(i => i.Price);
    }
}

class Program
{
    static void Main()
    {
        MenuManager manager = new MenuManager();

        manager.AddMenuItem("Spring Roll", "Appetizer", 120, true);
        manager.AddMenuItem("Paneer Butter", "Main Course", 250, true);
        manager.AddMenuItem("Chicken Curry", "Main Course", 300, false);
        manager.AddMenuItem("Ice Cream", "Dessert", 100, true);

        Console.WriteLine("Menu By Category:");

        var grouped = manager.GroupItemsByCategory();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var item in g.Value)
                Console.WriteLine(item.ItemName + " - " + item.Price);
        }

        Console.WriteLine("\nVegetarian Items:");

        foreach (var item in manager.GetVegetarianItems())
            Console.WriteLine(item.ItemName);

        Console.WriteLine("\nAverage Main Course Price: " +
            manager.CalculateAveragePriceByCategory("Main Course"));
    }
}
