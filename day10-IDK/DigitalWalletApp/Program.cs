using System;

namespace DigitalWalletApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digital Wallet Application - Module 1");

            Console.WriteLine("Number of arguments: " + args.Length);

            if (args.Length > 0)
            {
                Console.WriteLine("First argument: " + args[0]);
            }
        }
    }
}
