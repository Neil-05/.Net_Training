using System; // Console

namespace ItTechGenie.M1.GenericsDelegates.Q6
{
    public delegate void Notify(string message); // delegate type for notifications

    public class Program
    {
        public static void Main()
        {
            var hub = new NotificationHub();                         // central hub

            hub.Register(EmailSender.Send);                          // add email handler
            hub.Register(SmsSender.Send);                            // add sms handler
            hub.Register(AuditLogger.Log);                           // add audit handler

            hub.Publish("Order #5001 placed successfully.");          // trigger notification
        }
    }

    public class NotificationHub
    {
        private Notify? _pipeline;                                   // multicast chain

        public void Register(Notify handler) => _pipeline += handler;   // add handler
        public void Unregister(Notify handler) => _pipeline -= handler; // remove handler

        // ✅ TODO: Student must implement only this method
        public void Publish(string message)
        {
            // TODO:
            // 1) If _pipeline is null, do nothing.
            // 2) Invoke each delegate safely so one exception doesn't break others.
            if(_pipeline!=null)
            {
                foreach(Notify handler in _pipeline.GetInvocationList())
                {
                    try
                    {
                        handler(message);
                    
                }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Error in handler: {ex.Message}"); // log error but continue
                    }
                }
            }
        }
    }

    public static class EmailSender
    {
        public static void Send(string message) => Console.WriteLine($"EMAIL: {message}"); // simulate email
    }

    public static class SmsSender
    {
        public static void Send(string message) => Console.WriteLine($"SMS  : {message}"); // simulate sms
    }

    public static class AuditLogger
    {
        public static void Log(string message) => Console.WriteLine($"AUDIT: {message}"); // simulate audit log
    }
}