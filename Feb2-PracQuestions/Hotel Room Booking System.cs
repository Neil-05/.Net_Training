using System;
using System.Collections.Generic;

public class Room
{
    public int RoomNumber;
    public string RoomType;       
    public double PricePerNight;
    public bool IsAvailable;
}

public class HotelManager
{
    private List<Room> rooms = new List<Room>();

    
    public void AddRoom(int roomNumber, string type, double price)
    {
        
        foreach (Room r in rooms)
        {
            if (r.RoomNumber == roomNumber)
            {
                Console.WriteLine("Room already exists!");
                return;
            }
        }

        Room room = new Room();

        room.RoomNumber = roomNumber;
        room.RoomType = type;
        room.PricePerNight = price;
        room.IsAvailable = true;

        rooms.Add(room);

        Console.WriteLine("Room added successfully.");
    }

    
    public Dictionary<string, List<Room>> GroupRoomsByType()
    {
        Dictionary<string, List<Room>> result =
            new Dictionary<string, List<Room>>();

        foreach (Room r in rooms)
        {
            if (r.IsAvailable)
            {
                if (!result.ContainsKey(r.RoomType))
                {
                    result[r.RoomType] = new List<Room>();
                }

                result[r.RoomType].Add(r);
            }
        }

        return result;
    }

    
    public bool BookRoom(int roomNumber, int nights)
    {
        foreach (Room r in rooms)
        {
            if (r.RoomNumber == roomNumber)
            {
                if (!r.IsAvailable)
                {
                    Console.WriteLine("Room is already booked.");
                    return false;
                }

                double totalCost = r.PricePerNight * nights;

                r.IsAvailable = false;

                Console.WriteLine("Room booked successfully!");
                Console.WriteLine("Total Cost: ₹" + totalCost);

                return true;
            }
        }

        Console.WriteLine("Room not found.");
        return false;
    }

    
    public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
    {
        List<Room> result = new List<Room>();

        foreach (Room r in rooms)
        {
            if (r.IsAvailable &&
                r.PricePerNight >= min &&
                r.PricePerNight <= max)
            {
                result.Add(r);
            }
        }

        return result;
    }
}

public class Program
{
    static void Main()
    {
        HotelManager hotel = new HotelManager();

        // Add Rooms
        hotel.AddRoom(101, "Single", 1500);
        hotel.AddRoom(102, "Double", 2500);
        hotel.AddRoom(103, "Suite", 5000);
        hotel.AddRoom(104, "Single", 1800);
        hotel.AddRoom(105, "Double", 2700);

        Console.WriteLine("\nAvailable Rooms Grouped By Type:\n");

        
        var grouped = hotel.GroupRoomsByType();

        foreach (var item in grouped)
        {
            Console.WriteLine("Room Type: " + item.Key);

            foreach (Room r in item.Value)
            {
                Console.WriteLine($"  Room {r.RoomNumber} - ₹{r.PricePerNight}");
            }

            Console.WriteLine();
        }

        
        Console.WriteLine("Booking Room 102 for 3 nights:\n");

        hotel.BookRoom(102, 3);

        
        Console.WriteLine("\nRooms Between ₹1500 and ₹3000:\n");

        var budgetRooms =
            hotel.GetAvailableRoomsByPriceRange(1500, 3000);

        foreach (Room r in budgetRooms)
        {
            Console.WriteLine($"Room {r.RoomNumber} - {r.RoomType} - ₹{r.PricePerNight}");
        }

        Console.ReadLine();
    }
}

