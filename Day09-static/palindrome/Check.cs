namespace Palindrome
{
    public static class Check
    {
        public static bool result;

        static Check()
        {
            result = false;
        }
        public static void IsPalindrome(string? str)
        {
            str = str.Replace(" ", "").ToLower();
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            string reversed = new string(arr);
            result = str.Equals(reversed, StringComparison.OrdinalIgnoreCase);
        }
    }
}