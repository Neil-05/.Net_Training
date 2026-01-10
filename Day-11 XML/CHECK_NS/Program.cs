using System;
namespace CheckNS
{

    public  partial class Checker{
        public int ID{get;set;}
        public string name{get;set;}
        public string Addd()
        {
            return ID.ToString()+name;
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            Checker checker=new Checker();
            checker.ID=20;
            checker.name="dd";
            
            Console.WriteLine(checker.Addd());
            System.Xml.Serialization.XmlSerializer x=new System.Xml.Serialization.XmlSerializer(checker.GetType());
            x.Serialize(Console.Out,checker);
            Console.WriteLine();
            Console.ReadLine();

        }
}
}