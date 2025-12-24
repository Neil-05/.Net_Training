class Student
{
    // Data members
    private int rollNo;
    private string name;
    private int marks;

    // Constructor
    public Student(int rollNo, string name, int marks)
    {
        this.rollNo = rollNo;
        this.name = name;
        this.marks = marks;
    }

    // Member function to display details
    public void Display()
    {
        Console.WriteLine("Roll No: "+rollNo);
        Console.WriteLine("Name: "+name);
        Console.WriteLine("Marks: "+marks);
    }

    // Member function to check result
    public void Result()
    {
        if (marks >= 40)
            Console.WriteLine("Result: Pass");
        else
            Console.WriteLine("Result: Fail");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Student s1 = new Student(101, "Neil", 78);
        s1.Display();
        s1.Result();
    }
}
