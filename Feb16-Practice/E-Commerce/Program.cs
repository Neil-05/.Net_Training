public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }

// 1. Create a generic repository for products
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();

    // TODO: Implement method to add product with validation
    public void AddProduct(T product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        if (_products.Any(p => p.Id==product.Id)) throw new InvalidOperationException("Product ID must be unique");
        if (product.Price <= 0) throw new ArgumentException("Price must be positive");
        if (string.IsNullOrWhiteSpace(product.Name)) throw new ArgumentException("Name cannot be Null or Empty");
        _products.Add(product);

        // Rule: Product ID must be unique
        // Rule: Price must be positive
        // Rule: Name cannot be null or empty
        // Add to collection if validation passes
    }

    // TODO: Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        // Should return filtered products
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        return _products.Where(predicate);
    }

    // TODO: Calculate total inventory value
    public decimal CalculateTotalValue()
    {
        // Return sum of all product prices
        return _products.Sum(p => p.Price);

    }
    public List<T> GetAll() => _products;
}

// 2. Specialized electronic product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

// 3. Create a discounted product wrapper
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;

    public DiscountedProduct(T product, decimal discountPercentage)
    {
        // TODO: Initialize with validation
        // Discount must be between 0 and 100
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (discountPercentage < 0 || discountPercentage > 100)
            throw new ArgumentException("Discount must be between 0 and 100.");

        _product = product;
        _discountPercentage = discountPercentage;
    }

    // TODO: Implement calculated price with discount
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);

    // TODO: Override ToString to show discount details
    public override string ToString()
    {
        return $"{_product.Name} - Original: ${_product.Price}, " +
               $"Discount: {_discountPercentage}%, " +
               $"Final: ${DiscountedPrice:F2}";
    }
}

// 4. Inventory manager with constraints
public class InventoryManager
{
    // TODO: Create method that accepts any IProduct collection
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        // a) Print all product names and prices
        // b) Find the most expensive product
        // c) Group products by category
        // d) Apply 10% discount to Electronics over $500
       var productList = products.ToList();

        Console.WriteLine("All Products:");
        foreach (var p in productList)
            Console.WriteLine($"{p.Name} - ${p.Price}");

        var mostExpensive = productList.OrderByDescending(p => p.Price).FirstOrDefault();
        Console.WriteLine($"\nMost Expensive: {mostExpensive?.Name} - ${mostExpensive?.Price}");

        Console.WriteLine("\nGrouped by Category:");
        var grouped = productList.GroupBy(p => p.Category);
        foreach (var group in grouped)
        {
            Console.WriteLine($"Category: {group.Key}");
            foreach (var item in group)
                Console.WriteLine($"   {item.Name} - ${item.Price}");
        }

        Console.WriteLine("\nApplying 10% discount to Electronics over $500:");
        foreach (var p in productList.Where(p => p.Category == Category.Electronics && p.Price > 500))
        {
            var discounted = new DiscountedProduct<T>(p, 10);
            Console.WriteLine(discounted);
        }
    }

    // TODO: Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        // Apply priceAdjuster to each product
        // Handle exceptions gracefully
        for (int i = 0; i < products.Count; i++)
        {
            try
            {
                var newPrice = priceAdjuster(products[i]);

                if (newPrice <= 0)
                    throw new ArgumentException("Adjusted price must be positive.");

                // Using reflection since Price has no setter in interface
                var property = products[i].GetType().GetProperty("Price");
                property?.SetValue(products[i], newPrice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product {products[i].Name}: {ex.Message}");
            }
    }
}}

// 5. TEST SCENARIO: Your tasks:
// a) Implement all TODO methods with proper error handling
// b) Create a sample inventory with at least 5 products
// c) Demonstrate:
//    - Adding products with validation
//    - Finding products by brand (for electronics)
//    - Applying discounts
//    - Calculating total value before/after discount
//    - Handling a mixed collection of different product types
public class ClothingProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Clothing;
}

public class Program
{
    public static void Main()
    {
        var repo = new ProductRepository<IProduct>();

        var laptop = new ElectronicProduct
        {
            Id = 1,
            Name = "Gaming Laptop",
            Price = 1500,
            Brand = "Dell",
            WarrantyMonths = 24
        };

        var phone = new ElectronicProduct
        {
            Id = 2,
            Name = "Smartphone",
            Price = 800,
            Brand = "Apple",
            WarrantyMonths = 12
        };

        var shirt = new ClothingProduct
        {
            Id = 3,
            Name = "T-Shirt",
            Price = 25
        };

        var book = new ClothingProduct
        {
            Id = 4,
            Name = "Jacket",
            Price = 120
        };

        var headphones = new ElectronicProduct
        {
            Id = 5,
            Name = "Noise Cancelling Headphones",
            Price = 300,
            Brand = "Sony",
            WarrantyMonths = 18
        };

        // Add products
        repo.AddProduct(laptop);
        repo.AddProduct(phone);
        repo.AddProduct(shirt);
        repo.AddProduct(book);
        repo.AddProduct(headphones);

        Console.WriteLine($"Total Inventory Value: ${repo.CalculateTotalValue()}");

        // Find electronics by brand
        var dellProducts = repo.FindProducts(p =>
            p is ElectronicProduct e && e.Brand == "Dell");

        Console.WriteLine("\nProducts by Brand 'Dell':");
        foreach (var p in dellProducts)
            Console.WriteLine(p.Name);

        // Apply discount manually
        var discountedLaptop = new DiscountedProduct<IProduct>(laptop, 15);
        Console.WriteLine("\nDiscount Example:");
        Console.WriteLine(discountedLaptop);

        Console.WriteLine($"\nTotal Before Discount: ${repo.CalculateTotalValue()}");

        var manager = new InventoryManager();
        manager.ProcessProducts(repo.GetAll());

        // Bulk update example (increase all prices by 5%)
        manager.UpdatePrices(repo.GetAll(), p => p.Price * 1.05m);

        Console.WriteLine($"\nTotal After 5% Increase: ${repo.CalculateTotalValue()}");
    }
}

