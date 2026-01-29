using System;
using System.Collections.Generic;

namespace Q3_interface
{
    // interface
    public interface IPerson
    {
        string Name { get; }
        int Age { get; }
        string GetInfo();
    }

    // implementation
    public class Person : IPerson
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string GetInfo() => $"Name: {Name}, Age: {Age}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            // some data using the interface
            List<IPerson> people = new List<IPerson>
            {
                new Person("Alice", 30),
                new Person("Bob", 25),
                new Person("Charlie", 40)
            };

            foreach (var p in people)
            {
                Console.WriteLine(p.GetInfo());
            }
        }
    }
}