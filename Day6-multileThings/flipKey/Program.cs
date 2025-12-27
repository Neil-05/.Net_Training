using System;

namespace flipKey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the String:");
            string input = Console.ReadLine();
            string flipped = FlipKey(input);
            Console.WriteLine("answer: " + flipped);
        }
        public static string FlipKey(string str)
        {
            str = str.ToLower();
            char[] charArray = str.ToCharArray();
            if (string.IsNullOrEmpty(str) || str.Length < 6)
            {
                return "String is either empty or length is less than 6";
            }
            string ans="";
            for (int i = 0; i < charArray.Length; i++)
            {
                int x= (int)charArray[i];
                if(x%2!=0)
                {
                    ans+=charArray[i];
                }
            }
            char[] ar=ans.ToCharArray();
            Array.Reverse(ar);
            for(int i=0;i<ar.Length;i++)
            {
                if(i%2==0)
                {
                    ar[i]=char.ToUpper(ar[i]);
                }
            }
            return new string (ar);
        }
    }
}