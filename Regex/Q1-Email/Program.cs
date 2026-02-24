using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string [] args)
    {
        string email= "neilparkhe@gmail.com";
        bool isValid= Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        Console.WriteLine(isValid);
    }
}