using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
        {
            string input= "Neil@Parkhe#123%0501";
            string result= Regex.Replace(input, @"[^a-zA-z0-9]","");
            Console.Write(result);
    }
}