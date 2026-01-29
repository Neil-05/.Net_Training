using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Console.WriteLine("Program started at: " + DateTime.Now);
        
        // Console.WriteLine("Waiting for 10 seconds...");
        // Thread.Sleep(10000); // Sleep for 3000 milliseconds (3 seconds)
        
        // Console.WriteLine("Program resumed at: " + DateTime.Now);

        ThreadStart threadStart = new ThreadStart(PerformTasks);
        Thread thread = new Thread(threadStart);
        thread.Start();
        Console.WriteLine("For loop started at: " + DateTime.Now);
        for (int i = 1; i <= 15; i++)
        {
            Thread.Sleep(1000); // Sleep for 1 second
            Console.WriteLine(i+"  " );

        }
        Console.WriteLine("For loop ended at: " + DateTime.Now);

    }
    private static void PerformTasks()
    {
        Console.WriteLine("Another task started at: " + DateTime.Now);
        for (int j = 1; j <= 15; j++)
        {
            Thread.Sleep(500); // Sleep for 0.5 second
            Console.WriteLine(j + " ");
        }

    }
}