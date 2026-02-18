using System;
class Program
{
    class Person
    {
        public string name="Harsh";
    }
    static Person MakePerson() => new Person();
    static void Main(string[] args)
    {
        var P = MakePerson();
        Console.WriteLine(P.name);
    }
}   