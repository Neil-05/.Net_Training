namespace dele{
    
     public delegate void PrintMessage(string msg);
    public class program{
    public static void Methoda(string msg)=> Console.WriteLine("A" + msg);
    public static void Methodb(string msg)=>Console.WriteLine("B" + msg);
    public static void Methodc(string msg)=>Console.WriteLine("C"+msg);

     public static void Print(PrintMessage printer, string message)
        {
            printer(message);
        }
   public static void Main(string[] args)
        {
           
            PrintMessage p = Methoda;
            p += Methodb;
            p += Methodc;

            p("Neil");
    }
    }
}