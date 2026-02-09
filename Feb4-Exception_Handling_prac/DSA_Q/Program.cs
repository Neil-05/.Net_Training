using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter word1:");
        string word1 = Console.ReadLine();

        Console.WriteLine("Enter word2:");
        string word2 = Console.ReadLine();

        Dictionary<char, int> freq = new Dictionary<char, int>();
        foreach (char c in word2)
        {
            if (freq.ContainsKey(c))
                freq[c]++;
            else
                freq[c] = 1;
        }
        int deletions = 0;
        foreach (char c in word1)
        {
            if (freq.ContainsKey(c) && freq[c] > 0)
            {
                freq[c]--;
            }
            else
            {
                deletions++;
            }
        }
        Console.WriteLine(deletions);
    }
}
