public class Program
{
    public static void Main(string[] args)
    {
        string input=Console.ReadLine();
        string rev="";
        for(int i=input.Length-1;i>=0;i--)
        {
            rev+=input[i];
        }
        Console.WriteLine(rev);
    }
}