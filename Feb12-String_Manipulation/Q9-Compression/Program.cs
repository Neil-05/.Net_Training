public class Program
{
    public static void Main()
    {
        string input= "aaabbccccddeeeffggg";
        int left=1;
        int count=1;
        string res="";
        for(int right=0;right<input.Length-1;right++)
        {
            
            if(input[right] == input[right+1])
            {
                count++;
            }
            else
            {
                if(count>1) res+=input[right]+count.ToString();
                count=1;
            }

        }
        res+=input[input.Length-1]+count.ToString();
        Console.WriteLine(res);
    }
}