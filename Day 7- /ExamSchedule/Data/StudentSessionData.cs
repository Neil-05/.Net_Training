
using ExamSchedule.Model;
namespace ExamSchedule.Data{
    public class StudentSessionData{
        public static List<StudentsSession> studentsession =new List<StudentsSession>();
        static StudentSessionData()
        {
            studentsession.Add(new StudentsSession("2025CSE01", "Computer Science", "Year 2025"));
            studentsession.Add(new StudentsSession("2025CSE02", "Computer Science", "Year 2025"));
            studentsession.Add(new StudentsSession("2025AG03", "Agriculture", "Year 2025"));
            studentsession.Add(new StudentsSession("2025MEC04", "Mechanical", "Year 2025"));
        }

        public static List<StudentsSession> GetSession(){
            return studentsession;
        }
    }
}