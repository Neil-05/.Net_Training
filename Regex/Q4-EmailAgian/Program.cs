using System.Text.RegularExpressions;

public class Program
{
    public static string validateEmail(string email)
    {
        if(Regex.IsMatch(email, @"^[a-z]{3,}\.[a-z]{3,}\d{4,}@(hr|it|finance|admin)\.company\.com$")) return "Valid";
        else
        return "Invalid";
    }
    public static void Main(string[] args)
    {
        int n=int.Parse(Console.ReadLine());
        for(int i = 0; i < n; i++)
        {
            string x=Console.ReadLine();
            Console.WriteLine(validateEmail(x));
        }
    }
}