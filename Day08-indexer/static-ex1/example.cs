// preffered for distribution
// it will not go away from the memory
using System;
namespace staticClass
{
    public static class GeneralUses
    {
        public static int Rno;
        //public GeneralUses()
            // static class cannot have instance constructor because we cannot create instance of static class 
        static GeneralUses()
        {
            // static constructor will work only with static members
            Rno = 101;
        }
        public static int GetRno()
        {
            return Rno;
        }   
    }
}