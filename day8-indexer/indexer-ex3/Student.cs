using System.Collections.Generic;

namespace indexer_ex2
{
    class Student
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        private string Address;
        private List<string> books = new List<string>();

        public Student(string name, int age, string address)
        {
            Name = name;
            Age = age;
            Address = address;
        }

        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= books.Count)
                    return "Invalid index";
                return books[index];
            }
            set
            {
                if (index < books.Count)
                    books[index] = value;
                else if (index == books.Count)
                    books.Add(value);
            }
        }
    }
}
