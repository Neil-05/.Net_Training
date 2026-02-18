namespace indexer_ex2
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        private string Address;
        private string[] books = new string[3];

        public Student(string name, int age, string address)
        {
            Name = name;
            Age = age;
            Address = address;
        }

        public string this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }
    }

    class Program
    {
        static void Main()
        {
            Student obj = new Student();
            obj[0] = "Math";
            obj[1] = "Science";
            obj[2] = "History";

            Student s1 = new Student() { Name = "Alice", Age = 20, Address = "123 Main St" };
            Student s2 = new Student() { Name = "Bob", Age = 22, Address = "456 Oak Ave" };
            Student s3 = new Student() { Name = "Charlie", Age = 21, Address = "789 Pine Rd" };

            s1[0] = "English";
            s1[1] = "Art";
            s2[0] = "Biology";
            s2[1] = "Math";
            s2[2] = "Japanese";
            s3[0] = "Chemistry";

            Console.WriteLine($"{s1.Name}'s Books: {s1[0]}, {s1[1]}");
            Console.WriteLine($"{s2.Name}'s Books: {s2[0]}, {s2[1]}, {s2[2]}");
            Console.WriteLine($"{s3.Name}'s Books: {s3[0]}");
        }
    }
}