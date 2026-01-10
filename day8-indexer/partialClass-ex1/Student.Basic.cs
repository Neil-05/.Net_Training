using System;
namespace partialClass
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void ShowBasicInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}");
        }
    }
}