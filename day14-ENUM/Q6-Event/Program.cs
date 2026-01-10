namespace enuM{
    class Program{
    
    public delegate void Notify();
    public static event Notify Reached500;
    public static void Main(string[] args)
    {
        Reached500 += ValueReached500Plus;
        while(true)
        {
            Console.WriteLine("Enter a value or type Quit to exit");
            string x= Console.ReadLine();
            if(x.ToLower() == "quit") {
                break;
            }
            
            try{
                Console.WriteLine("Enter a value--");
                var input= int.Parse(Console.ReadLine());
                if(input >500){
                Reached500();
                }
                input=0;
            }
            catch(FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            
        }
    }
         private static void ValueReached500Plus()
        {
            Console.WriteLine("Yes Reached 500 or 500 plus please note");
        }

   
}}
