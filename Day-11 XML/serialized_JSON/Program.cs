using System;
using System.Text.Json;

namespace JsonExample
{
    // Model class
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create object
            Student student = new Student
            {
                Id = 1,
                Name = "Neil"
            };

            // JSON formatting options
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            // Serialize object to JSON
            string jsonData = JsonSerializer.Serialize(student, options);

            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(jsonData);

            Console.WriteLine("\n--------------------\n");

            // Deserialize JSON back to object
            Student? deserializedStudent =
                JsonSerializer.Deserialize<Student>(jsonData);

            Console.WriteLine("Deserialized Object:");
            Console.WriteLine($"ID: {deserializedStudent.Id}");
            Console.WriteLine($"Name: {deserializedStudent.Name}");

            Console.ReadLine();
        }
    }
}
