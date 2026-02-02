
namespace newPrac
{
    public class Program
    {
        public static SortedDictionary<int, Bike> bikeDetails =
            new SortedDictionary<int, Bike>();

        public static void Main(string[] args)
        {
            bool exit = false;
            BikeUtility bikeUtility = new BikeUtility();

            do
            {
                Console.WriteLine("1.Add Bike Details\n2.Group Bikes by Brand\n3.Exit");
                Console.WriteLine("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Bike Model :");
                        string model = Console.ReadLine();

                        Console.WriteLine("Enter Bike Brand :");
                        string brand = Console.ReadLine();

                        Console.WriteLine("Enter Bike Price :");
                        int price = int.Parse(Console.ReadLine());

                        bikeUtility.BikeDetails(model, brand, price);
                        break;

                    case 2:
                        var groupedBikes = bikeUtility.GroupBikesByBrand();
                        foreach (var b in groupedBikes)
                        {
                            Console.WriteLine($"Brand: {b.Key}");
                            foreach (var bike in b.Value)
                            {
                                Console.WriteLine($" Model: {bike.Model}, Price: {bike.Price}");
                            }
                        }
                        break;

                    case 3:
                        exit = true;
                        break;
                }

            } while (!exit);
        }
    }
}