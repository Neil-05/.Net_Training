using System.Text.RegularExpressions;
public class Program
{
    public static string validate(string address)
    {
        if(Regex.IsMatch(address,@"^[0-9a-fA-F]{1,4}(:[0-9a-fA-F]{1,4}){7}::([0-9A-F]{2}:){5}[0-9A-F]{2}$")) return "Authentic Device";
        else
        return "Rejected Device";
    }
    public static void Main(string[] args)
    {
        int n= int.Parse(Console.ReadLine);
        for(int i=0;i<n;i++)
        {
            string x= Console.ReadLine();
            Console.WriteLine(validate(x));
        }
    }
}