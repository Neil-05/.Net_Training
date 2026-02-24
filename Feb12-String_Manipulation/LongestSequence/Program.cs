public class Program
{
    public static void Main()
    {
        string input="abcabcbb";
        int left=0;
        int maxLength=0;
        HashSet<char> hash= new HashSet<char>();
        string res="";
        for(int right=0;right<input.Length;right++)
        {
            while(hash.Contains(input[right]))
            {
                hash.Remove(input[left]);
                left++;

            }
            hash.Add(input[right]);
            if(maxLength< right-left+1)
            {
               
                res=input.Substring(left, right-left+1);
            }
            maxLength= maxLength> right-left+1 ? maxLength: right-left+1;

        }
        Console.WriteLine(maxLength);
        Console.WriteLine(res);
       
    }
}