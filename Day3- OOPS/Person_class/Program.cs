class person{
    public int id{get; set; }
    public string name{get; set; }
    public int age{get; set;}
    

}
class Man : person{
    public string playing{get; set; }
    
    
}

class Woman : person{
    public string cooking{get; set; }
}

class Program
{
    public static void Main(string[] args)
    {
        Man m=new Man() {id=1, name="John", age=30, playing="Football"};
        Woman w=new Woman() {id=2, name="Jane", age=28, cooking="Pasta"};
        Console.WriteLine("Man Details:");
        Console.WriteLine($"ID: {m.id}, Name: {m.name}, Age: {m.age}, Playing: {m.playing}");

        Console.WriteLine();

        Console.WriteLine("Woman Details:");
        Console.WriteLine($"ID: {w.id}, Name: {w.name}, Age: {w.age}, Cooking: {w.cooking}");

        
    }
}