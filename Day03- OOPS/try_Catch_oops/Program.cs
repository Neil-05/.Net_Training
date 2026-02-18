namespace Oops
{
    public class MainConstructor
    {
        public static void Main(string[] args)
        {
            Visitor dd=new Visitor();
            try
            {
                Visitor visitor=new Visitor("John", 130);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Visitor
    {
        private string name;
        private int age;

        public Visitor()
        {
            // name= this.name;
            // age= this.age;  
        }

        public Visitor(string name, int age)
        {
            if (age < 0 || age > 120)
            {
                throw new ArgumentOutOfRangeException("age", "Age must be between 0 and 120.");
            }
            this.name = name;
            this.age = age;
        }
    }
}