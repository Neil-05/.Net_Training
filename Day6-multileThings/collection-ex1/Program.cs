using System;
using System.Collections;
class CollectionEx1
{
    public static void Main()
    {
        ArrayList al=new ArrayList();
        al.Add(100);
        al.Add(200);
        al.Add(700);
        al.Add(30);
        al.Add(70);
        al.Sort();
        Console.WriteLine("Elements in ArrayList of size :"+al.Count);
        for(int i=0;i<al.Count;i++)
        {
            Console.WriteLine(al[i]);
        }

    }
}