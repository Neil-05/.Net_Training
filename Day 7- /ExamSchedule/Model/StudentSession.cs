namespace ExamSchedule.Model{
public class StudentsSession{
        public StudentsSession(string id, string sessionName, string detail){
            ID=id;
            SessionName=sessionName;
            Detail=detail;
        }
        public string? ID{ get; set;}
        public string? SessionName{ get; set;}
        public  string? Detail{ get; set;}
    }
}