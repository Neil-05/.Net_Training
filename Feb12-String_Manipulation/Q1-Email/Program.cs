using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
                throw new Exception("Email cannot be empty");

            if (!input.Contains("@"))
                throw new Exception("There should be at least one @");

            string[] temp = input.Split('@');

            if (temp.Length != 2)
                throw new Exception("Invalid email format");

            if (!char.IsLetterOrDigit(temp[0][0]))
                throw new Exception("Wrong Pattern of Email!!! Can't start with special character");

            // Check consecutive dots
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '.' && input[i + 1] == '.')
                    throw new Exception("Invalid Email!!! There can't be consecutive periods.");
            }

            // Only allow letters, digits and dot
            if (Regex.IsMatch(input, @"[^a-zA-Z0-9.@]"))
                throw new Exception("Special characters are not allowed except '.' and '@'");

            // Domain must contain dot
            if (!temp[1].Contains("."))
                throw new Exception("There should be a domain name after @");

            Console.WriteLine("Valid Email ✅");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
