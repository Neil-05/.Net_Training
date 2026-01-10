namespace ENUM{
    public class AppCustomException: Exception{
        public override string Message => "Internal Error";
    }

    public class Program{
        public static void Main(string[] args)
        {
            try{
               int a = 1;
                int b = 0;     // not a constant expression anymore
                int x = a / b; // runtime DivideByZeroException
            }
            catch(Exception ){
                throw new AppCustomException();
            }
        }
        
    }
}