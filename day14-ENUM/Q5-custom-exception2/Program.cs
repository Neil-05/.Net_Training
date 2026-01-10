namespace Enum{
    public class AppCustomException: Exception{
        public override string Message => HandleBase(base.Message);

        private string HandleBase(string sysMessage)
        {
            Console.WriteLine(sysMessage);
            return "Internal Exception Occured. Please contact Admin";
        }

    }
    public class Program{
        public static void Main(string[] args)
        {
            try{
               int a = 1;
                int b = 0;     
                int x = a / b; 
            }
            catch(Exception ){
                throw new AppCustomException();
            }
        }
    }
}