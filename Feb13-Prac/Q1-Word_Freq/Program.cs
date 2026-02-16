using Microsoft.VisualBasic;

public class Program
{
    public static void Main(string [] args)
    {
        string input= Console.ReadLine();
        string []tokens= input.Split(" ");
        Dictionary<string,int> dict=new Dictionary<string, int>();
        foreach(string x in tokens)
        {
            if(!dict.ContainsKey(x))
            {
                dict[x]=1;
            }
            else
            {
                dict[x]++;
            } 

        }
        foreach(var pair in dict)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");

        }

    }
}