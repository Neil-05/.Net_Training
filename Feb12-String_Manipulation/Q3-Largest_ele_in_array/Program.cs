public class Program
{
    public static void Main(string[]  args )
    {
        int[] arr={1,5,2,6,2,1,6,1};
        int max=arr[0];
        for(int i=1;i<arr.Length;i++)
        {
            if(arr[i]> max)
            max=arr[i];
        }
        Console.WriteLine(max);
    }
}