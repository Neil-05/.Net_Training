public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = {5,2,6,1,6,2,1,6,2,1,6,2,2};
        List<int> list=new List<int>();
        HashSet<int> hash=new HashSet<int>();
        for(int i=0;i<arr.Length;i++)
        {
            if(!hash.Contains(arr[i])){
            list.Add(arr[i]);
            hash.Add(arr[i]);
            }

        }
        int [] arr2=list.ToArray();
        foreach(int x in arr2)
        {
            Console.WriteLine(x);
        }
    }
}