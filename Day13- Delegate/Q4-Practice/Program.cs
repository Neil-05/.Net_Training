namespace practice{
    public class Employee{
        public int ID { get; set; }
        public string Name { get; set; }
        public Employee(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public string Display(int id, string name)
        {
            return "The " + id + " is issued to " + name;
        }
    }
    public class program
    {
        public static void Main(string[] args)
        {
            Employee e=new Employee(1,"Neil");
             Console.WriteLine(e.Display(e.ID, e.Name));
            
        }
    }
}