namespace ConstructorClass
{
    public class Student
    {
        public int Id;
        public string Name;

        // Public constructor
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Display()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Name: " + Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student(101, "Neil");
            s.Display();
        }
    }
}
