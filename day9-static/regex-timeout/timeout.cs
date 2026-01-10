using System;
using System.Text.RegularExpressions;

namespace Timeout
{
    class Time
    {
        public static void apicall()
        {
            string input = "Error: Timeout occurred while connecting to the server.";
            string pattern = @"timeout";

            var rx = new Regex(
                pattern,
                RegexOptions.IgnoreCase,
                TimeSpan.FromMilliseconds(200)
            );

            bool isMatch = rx.IsMatch(input);
            Console.WriteLine($"Does the input match the pattern? {isMatch}");
        }
    }
}
