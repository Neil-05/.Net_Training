using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        var list =new List<byte[]>();
        for(int i=0;i<20000;i++)
        {
            list.Add(new byte[1024]);
        }   
        Console.WriteLine("Total Memory: " + GC.GetTotalMemory(forceFullCollection:false)/1024 + " KB");
        GC.Collect();
        Console.WriteLine("After GC.Collect()");
        Console.WriteLine("Total Memory: " + GC.GetTotalMemory(forceFullCollection:true)/1024 + " KB");
    }
}