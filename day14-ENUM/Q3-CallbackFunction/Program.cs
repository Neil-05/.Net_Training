// Program.cs
using System;

namespace CallbacksWithDelegates
{
    // 1) Create a delegate type (signature: void (string))
    public delegate void Notify(string message);

    class OrderService
    {
        // 2) Accept a delegate as parameter (callback)
        public void PlaceOrder(string orderId, Notify callback)
        {
            Console.WriteLine($"Order {orderId} placed.");

            // 3) Call the callback (when something important happens)
            callback?.Invoke($"Order {orderId} confirmation sent!");
        }
    }

    class Program
    {
        static void Main()
        {
            var service = new OrderService();

            // Pass a method as callback
            service.PlaceOrder("ORD-101", SendEmail);

            // Pass another method as callback
            service.PlaceOrder("ORD-102", SendSms);
        }

        static void SendEmail(string msg) => Console.WriteLine("EMAIL: " + msg);
        static void SendSms(string msg) => Console.WriteLine("SMS:   " + msg);
    }
}