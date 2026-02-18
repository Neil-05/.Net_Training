interface Iveg{
    void vegeater();
    string gettaste();

}
interface Inonveg{
    void noneater();
    string gettaste();
}



class visitor : Iveg, Inonveg
{
       public void visit()
    {
        Console.WriteLine("I am a visitor");
    }

    public void vegeater()
    {
        Console.WriteLine("I am a veg eater");
    }
     string Iveg.gettaste()
    {
        return "Taste depends on the Spices ";
    }
    
    public void noneater()
    {
        Console.WriteLine("I am a non veg eater");
        
    }
    string Inonveg.gettaste()
    {
        return "Taste depends on the marination";
    }
   
 
}


class Program
{
    static void Main(string[] args)
    {
        visitor v = new visitor();
         v.visit();
        v.vegeater();
        
     
        v.noneater();
        Console.WriteLine("\n");
        Iveg iv=new visitor();
        string vtaste=iv.gettaste();
        Inonveg inv=new visitor();
        string nvtaste=inv.gettaste();
        Console.WriteLine("Veg taste: "+vtaste);
        Console.WriteLine("Non Veg taste: "+nvtaste);

        
       
    }
}