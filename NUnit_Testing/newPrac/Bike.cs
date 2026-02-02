namespace newPrac
{
    public class Bike
    {
     public string Model { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }

        public Bike(string model, string brand, int price)
        {
            Model = model;
            Brand = brand;
            Price = price;
        }
    }
}