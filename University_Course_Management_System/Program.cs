using University_Course_Registration_System;

namespace University_Course_Management_System{
class Program
{
    static void Main()
    {
        UniversitySystem system = new UniversitySystem();
        bool exit = false;

        Console.WriteLine("Welcome to University Course Registration System");

        while (!exit)
        {
            Console.WriteLine("\n1. Add Course");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Register Student for Course");
            Console.WriteLine("4. Drop Student from Course");
            Console.WriteLine("5. Display All Courses");
            Console.WriteLine("6. Display Student Schedule");
            Console.WriteLine("7. Display System Summary");
            Console.WriteLine("8. Exit");

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter course code: ");
                        string code = Console.ReadLine();

                        Console.Write("Enter course name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter credits: ");
                        int credits = int.Parse(Console.ReadLine());

                        Console.Write("Enter max capacity (press Enter for default 50): ");
                        string capInput = Console.ReadLine();
                        int maxCapacity = string.IsNullOrEmpty(capInput) ? 50 : int.Parse(capInput);

                        Console.Write("Enter prerequisites (comma-separated or leave empty): ");
                        string prereqInput = Console.ReadLine();
                        List<string> prerequisites = string.IsNullOrEmpty(prereqInput)
                            ? null
                            : prereqInput.Split(',').Select(p => p.Trim()).ToList();

                        system.AddCourse(code, name, credits, maxCapacity, prerequisites);
                        break;

                    case "2":
                        Console.Write("Enter student ID: ");
                        string id = Console.ReadLine();

                        Console.Write("Enter student name: ");
                        string studentName = Console.ReadLine();

                        Console.Write("Enter major: ");
                        string major = Console.ReadLine();

                        Console.Write("Enter max credits (press Enter for default 18): ");
                        string maxCredInput = Console.ReadLine();
                        int maxCredits = string.IsNullOrEmpty(maxCredInput) ? 18 : int.Parse(maxCredInput);

                        Console.Write("Enter completed courses (comma-separated or leave empty): ");
                        string completedInput = Console.ReadLine();
                        List<string> completedCourses = string.IsNullOrEmpty(completedInput)
                            ? null
                            : completedInput.Split(',').Select(c => c.Trim()).ToList();

                        system.AddStudent(id, studentName, major, maxCredits, completedCourses);
                        break;

                    case "3":
                        Console.Write("Enter student ID: ");
                        string studentId = Console.ReadLine();

                        Console.Write("Enter course code: ");
                        string courseCode = Console.ReadLine();

                        system.RegisterStudentForCourse(studentId, courseCode);
                        break;

                    case "4":
                        Console.Write("Enter student ID: ");
                        string dropStudentId = Console.ReadLine();

                        Console.Write("Enter course code: ");
                        string dropCourseCode = Console.ReadLine();

                        system.DropStudentFromCourse(dropStudentId, dropCourseCode);
                        break;

                    case "5":
                        system.DisplayAllCourses();
                        break;

                    case "6":
                        Console.Write("Enter student ID: ");
                        string scheduleId = Console.ReadLine();
                        system.DisplayStudentSchedule(scheduleId);
                        break;

                    case "7":
                        system.DisplaySystemSummary();
                        break;

                    case "8":
                        exit = true;
                        Console.WriteLine("Exiting system...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
}