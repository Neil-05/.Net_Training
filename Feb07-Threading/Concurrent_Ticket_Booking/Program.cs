using System;
using System.Collections.Generic;
using System.Threading;

public class Program
{
    public SortedDictionary<int, bool> seats = new SortedDictionary<int, bool>();
    private readonly object seatLock = new object();

    public static void Main(string[] args)
    {
        Program p = new Program();
        Thread t1 = new Thread(() => p.TryBook(1, "Neil"));
        Thread t2 = new Thread(() => p.TryBook(1, "Harass"));
        Thread t3 = new Thread(() => p.TryBook(1, "amul"));

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine("Final booked seats:");
        foreach (var seat in p.seats)
        {
            Console.WriteLine($"Seat {seat.Key} booked");
        }
    }

    public void TryBook(int seatNumber, string userId)
    {
        bool result = Bookseat(seatNumber, userId);

        Console.WriteLine(
            $"{Thread.CurrentThread.ManagedThreadId} | {userId} | " +
            (result ? "SUCCESS" : "FAILED")
        );
    }

    public bool Bookseat(int seatNumber, string userID)
    {
        lock (seatLock)
        {
            if (seats.ContainsKey(seatNumber))
                return false;

           
            Thread.Sleep(500);

            seats.Add(seatNumber, true);
            return true;
        }
    }
}
