using System;

public delegate void Notify();

class Process
{
    public void StartProcess(Notify notify)
    {
        Console.WriteLine("Process Started...");
        notify();   // callback
    }
}

class Program
{
    public static void OnProcessCompleted()
    {
        Console.WriteLine("Process Completed!");
    }

    static void Main()
    {
        Process p = new Process();
        Notify del = OnProcessCompleted;

        p.StartProcess(del);
    }
}
