using System;
using System.Collections.Generic;
using System.Linq;

class Restaurant
{
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string CuisineType { get; set; }
    public string Location { get; set; }
    public double DeliveryCharge { get; set; }
}

class FoodItem
{
    public int ItemId { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int RestaurantId { get; set; }
}

class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public List<FoodItem> Items { get; set; } = new List<FoodItem>();
    public DateTime OrderTime { get; set; }
    public string Status { get; set; }
    public double TotalAmount { get; set; }
}

class DeliveryManager
{
    private List<Restaurant> restaurants = new List<Restaurant>();
    private List<FoodItem> foods = new List<FoodItem>();
    private List<Order> orders = new List<Order>();

    private int rCounter = 1;
    private int fCounter = 1;
    private int oCounter = 1;

    public void AddRestaurant(string name, string cuisine,
                              string location, double charge)
    {
        restaurants.Add(new Restaurant
        {
            RestaurantId = rCounter++,
            Name = name,
            CuisineType = cuisine,
            Location = location,
            DeliveryCharge = charge
        });
    }

    public void AddFoodItem(int rid, string name,
                            string cat, double price)
    {
        foods.Add(new FoodItem
        {
            ItemId = fCounter++,
            Name = name,
            Category = cat,
            Price = price,
            RestaurantId = rid
        });
    }

    public Dictionary<string, List<Restaurant>> GroupRestaurantsByCuisine()
    {
        return restaurants.GroupBy(r => r.CuisineType)
                          .ToDictionary(g => g.Key, g => g.ToList());
    }

    public bool PlaceOrder(int cid, List<int> itemIds)
    {
        var list = foods.Where(f => itemIds.Contains(f.ItemId)).ToList();

        if (list.Count == 0) return false;

        double total = list.Sum(i => i.Price);

        orders.Add(new Order
        {
            OrderId = oCounter++,
            CustomerId = cid,
            Items = list,
            OrderTime = DateTime.Now,
            Status = "Pending",
            TotalAmount = total
        });

        return true;
    }

    public List<Order> GetPendingOrders()
    {
        return orders.Where(o => o.Status == "Pending").ToList();
    }
}

class Program
{
    static void Main()
    {
        DeliveryManager manager = new DeliveryManager();

        manager.AddRestaurant("Tandoori Hub", "Indian", "Delhi", 40);
        manager.AddRestaurant("Pizza Zone", "Italian", "Noida", 30);

        manager.AddFoodItem(1, "Butter Chicken", "Main", 250);
        manager.AddFoodItem(1, "Naan", "Bread", 40);
        manager.AddFoodItem(2, "Pizza", "Main", 300);

        manager.PlaceOrder(101, new List<int> { 1, 2 });

        Console.WriteLine("Restaurants By Cuisine:");

        var grouped = manager.GroupRestaurantsByCuisine();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var r in g.Value)
                Console.WriteLine(r.Name);
        }

        Console.WriteLine("\nPending Orders:");

        foreach (var o in manager.GetPendingOrders())
            Console.WriteLine("Order " + o.OrderId +
                              " Amount " + o.TotalAmount);
    }
}
