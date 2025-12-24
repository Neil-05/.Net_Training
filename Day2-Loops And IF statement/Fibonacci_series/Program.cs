class Program{
    public static void Main(string[] args){
        Console.WriteLine("Enter the number of terms:");
        int n= int.Parse(Console.ReadLine());
        int a=0;
        int b=1;
        Console.WriteLine(a+"\n"+b);
        while(n-2>0){
            int c=a+b;
            Console.WriteLine(c);
            a=b;
            b=c;
            n--;
        }
        
    }
}