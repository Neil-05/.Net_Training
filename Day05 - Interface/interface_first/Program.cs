interface Ifirst{
    int add(int a, int b);
}

class Calculator : Ifirst{
    public int add(int a, int b){
       return a+b;
    }
}
   
class Program{
    public static void Main(string[] args){
        Ifirst calc=new Calculator();
        Console.WriteLine("Sum: " + calc.add(5, 10));
    }
}