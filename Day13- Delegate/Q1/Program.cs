using System;
namespace dele{
    public delegate string PrintMessage(string message);

    public class PrintingCompany
    {
        public PrintMessage CustomerChoicePrintMessage{get; set;}

        public void Print(string message)
        {
            string messageToPrint= CustomerChoicePrintMessage(message);
            Console.WriteLine(messageToPrint);
        }
    }
public class Program{

    private static string HappyNewYear(string Message)
    {
        return " Welcome to Delegate World -- Happy New Year "+ Message;
    }
    public static void Main(string[] args)
    {
        PrintingCompany print= new PrintingCompany();
        print.CustomerChoicePrintMessage=new PrintMessage(HappyNewYear);
        

        string x= Console.ReadLine();
        print.Print(x);
    }
}

}