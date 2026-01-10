using System;
namespace partialClass
{
    public partial class Student
    {
        public int Marks { get; set; }
        public void ShowMarks()
        {
            Console.WriteLine($"Marks: {Marks}");
        }
    }
}