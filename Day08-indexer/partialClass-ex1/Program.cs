using System;

namespace partialClass
{
    class Program
    {
        static void Main()
        {
            Student s = new Student();
            s.Id = 101;
            s.Name = "Harsh";
            s.Marks = 92;

            s.ShowBasicInfo();
            s.ShowMarks();
        }
    }
}
