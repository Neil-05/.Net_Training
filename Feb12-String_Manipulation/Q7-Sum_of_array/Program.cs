public class Program
{
    public static void Main(string[] args)
    {
        int[] arr= {5,6,1,7,1,6,7,1,2,7,2,1,8,2,7,9,2,1,5,6};
        int sum=0;
        foreach(int x in arr)
        {
            sum+=x;
        }
        Console.WriteLine(sum);
    }
    
}