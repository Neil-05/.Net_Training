using System;

namespace indexer_ex2
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            Student[] students = new Student[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Enter details for Student {i + 1} ---");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Address: ");
                string address = Console.ReadLine();

                students[i] = new Student(name, age, address);

                Console.Write("How many books? ");
                int bookCount = int.Parse(Console.ReadLine());

                for (int j = 0; j < bookCount; j++)
                {
                    Console.Write($"Enter book {j + 1}: ");
                    students[i][j] = Console.ReadLine();
                }
            }

            Console.WriteLine("\n========= STUDENT DETAILS =========");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nStudent {i + 1}");
                Console.WriteLine($"Name: {students[i].Name}");
                Console.WriteLine($"Age : {students[i].Age}");

                Console.WriteLine("Books:");
                int k = 0;
                while (true)
                {
                    string book = students[i][k];
                    if (book == "Invalid index")
                        break;

                    Console.WriteLine($"- {book}");
                    k++;
                }
            }
        }
    }
}
