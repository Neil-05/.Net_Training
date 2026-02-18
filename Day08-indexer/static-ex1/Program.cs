using System;
namespace staticClass
{
    class Program
    {
        static void Main()
        {
            // GeneralUses gu = new GeneralUses(); object cannot be created of static class
            // because static class members are accessed by class name
            Console.WriteLine("Rno: " + GeneralUses.Rno);
        }
    }
}