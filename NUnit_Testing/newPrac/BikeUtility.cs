namespace newPrac{
public class BikeUtility
    {
        public void BikeDetails(string model, string brand, int price)
        {
            int key = Program.bikeDetails.Count + 1;
            Program.bikeDetails.Add(key, new Bike(model, brand, price));
        }

        public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
        {
            SortedDictionary<string, List<Bike>> brandMap =
                new SortedDictionary<string, List<Bike>>();

            foreach (var bike in Program.bikeDetails.Values)
            {
                if (!brandMap.ContainsKey(bike.Brand))
                {
                    brandMap[bike.Brand] = new List<Bike>();
                }
                brandMap[bike.Brand].Add(bike);
            }
            return brandMap;
        }
    }
}
