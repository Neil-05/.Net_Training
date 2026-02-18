using System;
using System.ComponentModel;
namespace indexer_ex1
{
    class Sample
    {
        private int [] arr = new int [4];
        public int this [int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sample obj = new Sample();
            obj[0]= 10;
            obj[1]= 20;
            obj[2]= 30;
            obj[0]+=5;
            obj[3]= 40;
            Console.WriteLine("Element at index 0: " + obj[0]);
            Console.WriteLine("Element at index 1: " + obj[1]);
            Console.WriteLine("Element at index 2: " + obj[2]);
            Console.WriteLine("Element at index 3: " + obj[3]);
        }
    }
}