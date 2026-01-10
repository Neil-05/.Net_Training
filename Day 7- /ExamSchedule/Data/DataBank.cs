using ExamSchedule.Model;
namespace ExamSchedule.Data{
     public class DataBank{
        public static List<Student> Students = new List<Student>();
        static DataBank(){
            Students.Add(new Student{ID=1, Name="Alice"});
            Students.Add(new Student{ID=2, Name="Bob"});
            Students.Add(new Student{ID=3, Name="Charlie"});
            Students.Add(new Student{ID=4, Name="Diana"});
        }
        public static List<Student> GetStudents(){
            return Students;
        }
    // }
    }
}