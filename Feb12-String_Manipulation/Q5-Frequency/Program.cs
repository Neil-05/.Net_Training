public class Program
{
    public static void Main(string[] args)
    {
        int[] arr= {5,6,1,7,1,6,7,1,2,7,2,1,8,2,7,9,2,1,5,6};
        Dictionary<int,int> dict=new Dictionary<int, int>();
        foreach(int x in arr)
        {
            if(!dict.ContainsKey(x))
            {
                dict.Add(x,1);

            }
            else
            {
                dict[x] = dict[x]+1;
            }
        }
        foreach(var pair in dict)
        {
            Console.WriteLine($"{pair.Key} : {pair.Value}");
        }
    }
}