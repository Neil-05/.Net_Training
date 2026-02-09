// See https://aka.ms/new-console-template for more information
using System.Collections;

class Even
{
    public static bool isEven(int n)
    {
        return n%2==0;
    }
    public static void Main(string[] args)
    {   
        // Even even=new Even();
        Console.WriteLine("Enter a number:");
        int n=int.Parse(Console.ReadLine());
        bool x= isEven(n);
        if(x)
        {
            Console.WriteLine("Even");
        }
        else
        {
            Console.WriteLine("Odd");
        }
    }
}



public class Generic<T,U>
{
    public T name{get;set;}
    public U age{get; set;}
    public Generic(T name, U age)
    {
        this.name=name;
        this.age=age;
    
}
}
public class Program
{
    public static void Main(string[] args)
    {
        Generic<string,int> g=new Generic<string,int>("Neil",22);
        Console.WriteLine($"Name: {g.name}, Age: {g.age}");
        


        ArrayList list=new ArrayList();
        list.Add(1);
        list.Add("Hello");
        list.Add(3.14);

    }
}