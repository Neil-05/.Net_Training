namespace RegEx
{
    class Program
    {
        static void Main()
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Console.WriteLine("Enter the email:");
            string input = Console.ReadLine();
            bool isMatch = System.Text.RegularExpressions.Regex.IsMatch(input, pattern);
            Console.WriteLine($"Does the input match the pattern? {isMatch}");
        }
    }
}