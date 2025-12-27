using System;

namespace Fish
{
    public interface Ifish1
    {
        public void Swim();
        public void Walk();
    }
    public interface Ifish2
    {
        public void Sing();
        public void Dance();
    }
    public class fish1
    {
        public void Swim()
        {
            Console.WriteLine("fish can swim");
        }
        public void Walk()
        {
            Console.WriteLine("fish can walk");
        }
    }
    public class fish2
    {
        public void Sing()
        {
            Console.WriteLine("fish can sing");
        }
        public void Dance()
        {
            Console.WriteLine("fish can dance");
        }
    }
    public class fish : Ifish1, Ifish2
    {
        fish1 f1 = new fish1();
        fish2 f2 = new fish2();

        public void Swim()
        {
            f1.Swim();
        }
        public void Walk()
        {
            f1.Walk();
        }
        public void Sing()
        {
            f2.Sing();
        }
        public void Dance()
        {
            f2.Dance();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            fish f = new fish();
            Ifish1 fish1 = f;
            fish1.Swim();
            fish1.Walk();
            Ifish2 fish2 = f;
            fish2.Sing();
            fish2.Dance();
        }
    }
}