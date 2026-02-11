using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            // TODO:
            // 1. Throw ArgumentException if course code exists
            // 2. Create Course object
            // 3. Add to AvailableCourses
            if (AvailableCourses.ContainsKey(code))
                throw new ArgumentException("Course Already Exists");
            else
            {
                Course course = new Course(code, name, credits, maxCapacity, prerequisites);
                AvailableCourses.Add(code, course);
                Console.WriteLine("Course Added Successfully....");
            }
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            // TODO:
            // 1. Throw ArgumentException if student ID exists
            // 2. Create Student object
            // 3. Add to Students dictionary
            if (Students.ContainsKey(id))
                throw new ArgumentException("Student ID already Exists");
            else
            {
                Student student = new Student(id, name, major, maxCredits, completedCourses);
                Students.Add(id, student);
                Console.WriteLine("Student Added Successfully");
            }
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found.");
                return false;
            }

            if (!AvailableCourses.ContainsKey(courseCode))
            {
                Console.WriteLine("Course not found.");
                return false;
            }

            Student student = Students[studentId];
            Course course = AvailableCourses[courseCode];

            bool success = student.AddCourse(course);

            if (success)
                Console.WriteLine("Congratulations!!!!! Student registered successfully.");
            else
                Console.WriteLine("Registration failed.");

            return success;
        }


        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found.");
                return false;
            }

            bool success = Students[studentId].DropCourse(courseCode);

            if (success)
                Console.WriteLine("Course dropped successfully.");
            else
                Console.WriteLine("Drop failed.");

            return success;
        }
        public void DisplayAllCourses()
        {
            // TODO:
            // Display course code, name, credits, enrollment info
            if (AvailableCourses.Count == 0)
            {
                Console.WriteLine("No Course Available");
                return;
            }
            foreach (var course in AvailableCourses.Values)
            {
                Console.WriteLine($"Course Code: {course.CourseCode}       ||       Course Name: {course.CourseName}       ||       Course Credits {course.Credits}       ||       Enrolled: {course.CurrentEnrollment}/{course.MaxCapacity}       ||       Prerequisites: {course.Prerequisites}");
            }

        }

        public void DisplayStudentSchedule(string studentId)
        {
            // TODO:
            // Validate student existence
            // Call student.DisplaySchedule()
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Students[studentId].DisplaySchedule();
        }

        public void DisplaySystemSummary()
        {
            // TODO:
            // Display total students, total courses, average enrollment
            int totalStudents = Students.Count;
            int totalCourses = AvailableCourses.Count;

            int totalEnrollment = AvailableCourses.Values.Sum(c => c.CurrentEnrollment);
            double averageEnrollment = totalCourses == 0 ? 0 : (double)totalEnrollment / totalCourses;

            Console.WriteLine($"Total Students: {totalStudents}");
            Console.WriteLine($"Total Courses: {totalCourses}");
            Console.WriteLine($"Average Enrollment per Course: {averageEnrollment:F2}");
        }
    }
}
