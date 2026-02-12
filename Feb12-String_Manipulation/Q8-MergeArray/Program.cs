public class Program
{
    public static void Main(string[] args)
    {
        int[] arr= {1,3,5,7,9};
        int[] arr2= {2,4,6,8,11};
        int i=0;
        int j=0;
        int[] arr3=new int[arr.Length+arr2.Length];
        int n=0;
        while(i < arr.Length && j < arr2.Length)
        {
            if (arr[i] < arr2[j])
            {
                arr3[n++] = arr[i++];
            }
            else
            {
                arr3[n++] = arr2[j++];
            }

        }

          while (i < arr.Length)
        {
            arr3[n++] = arr[i++];
        }

        while (j < arr2.Length)
        {
            arr3[n++] = arr2[j++];
        }

   
        foreach(int x in arr3)
        {
            Console.WriteLine(x);
        }
        
    }
    
}