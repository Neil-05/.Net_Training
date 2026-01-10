using ExamSchedule.Data;
namespace ExamSchedule
{
    

    

   

   

    public class Program
    {
        public static void Main(string[] args)
        {
            var students = DataBank.GetStudents();
            foreach(var student in students){
                Console.WriteLine($"ID: {student.ID}, Name: {student.Name}");
            }

            var sessions = StudentSessionData.GetSession();

            foreach (var s in sessions)
            {
                Console.WriteLine(
                    $"ID: {s.ID}, Session Name: {s.SessionName}, Detail: {s.Detail}"
                );
            }
        }
    }
}