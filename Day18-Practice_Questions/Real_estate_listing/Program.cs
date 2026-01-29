public interface IListing
{
    int ID { get; set; }
    string Title { get; set; }
    string Description { get; set; }
    decimal Price { get; set; }
    string Location { get; set; }
}
public class RealEstateListing : IListing

{
   public int ID { get; set; }
   public string Title { get; set; }

   public string Description{get; set;}

   public decimal Price { get; set; }

    public string Location { get; set; }    

    public RealEstateListing(int id, string title, string description, decimal price, string location)
    {
        ID = id;
        Title = title;
        Description = description;
        Price = price;
        Location = location;
    }   
    public override string ToString()
    {
        return $"ID: {ID}, Title: {Title}, Description: {Description}, Price: {Price}, Location: {Location}";
    }

}
public class RealEstateApp
{
    private List<RealEstateListing> listings = new List<RealEstateListing>();
    public void AddListing(RealEstateListing listing)
    {
        listings.Add(listing);
    }
    public void RemoveListing(int id)
    {
        listings.RemoveAll(l=>l.ID==id);
    }
    public void UpdateListing(IListing updatedListing)
    {
        var listing = listings.FirstOrDefault(l=>l.ID==updatedListing.ID);
        if(listing !=null)
        {
            listing.Title =updatedListing.Title;
            listing.Description = updatedListing.Description;
            listing.Price = updatedListing.Price;
            listing.Location = updatedListing.Location; 
            
            Console.WriteLine("Listing Updated Successfully");
        }
        else
        {
            Console.WriteLine("Listing Not Found");
        }
    }

    public List<RealEstateListing> GetListing()
    {
        return listings;
    }
    
    public List<RealEstateListing> GetListingsByLocation(string location)
    {
        return listings.Where(l=>listings.location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public List<RealEstateListing> GetListingsByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return listings.Where(l=>l.Price >= minPrice && l.Price <= maxPrice).ToList();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        RealEstateApp app = new RealEstateApp();

        RealEstateListing listing1 = new RealEstateListing(1, "Cozy Apartment", "A cozy apartment in the city center", 150000, "New York");
        RealEstateListing listing2 = new RealEstateListing(2, "Spacious Villa", "A spacious villa with a garden", 500000, "Los Angeles");

        app.AddListing(listing1);
        app.AddListing(listing2);

        Console.WriteLine("All Listings:");
        foreach(var listing in app.GetListing())
        {
            Console.WriteLine(listing);
        }

        Console.WriteLine("\nListings in New York:");
        foreach(var listing in app.GetListingsByLocation("New York"))
        {
            Console.WriteLine(listing);
        }

        Console.WriteLine("\nListings in Price Range 100000 to 300000:");
        foreach(var listing in app.GetListingsByPriceRange(100000, 300000))
        {
            Console.WriteLine(listing);
        }

        // Update Listing
        IListing updatedListing = new RealEstateListing(1, "Cozy Apartment Updated", "An updated cozy apartment in the city center", 160000, "New York");
        app.UpdateListing(updatedListing);

        Console.WriteLine("\nAll Listings After Update:");
        foreach(var listing in app.GetListing())
        {
            Console.WriteLine(listing);
        }
    }
}