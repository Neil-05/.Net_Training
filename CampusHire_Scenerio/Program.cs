public class CampusHire
{
    public string ApplicantID;
    public string Name;
    public string Location;

    public string PrefLocation;

    public string Core;

    public int PassingYear;
   
    public CampusHire(string applicantid, string name, string location, string preflocation, string core, int passingyear){
        ApplicantID= applicantid;
        Name=name;
        Location= location;
        PrefLocation= preflocation;
        Core= core;
        PassingYear=passingyear;
        
        
    }


}
public class Operations
{
    private List<CampusHire> students= new List<CampusHire>();

    public void AddStudent(CampusHire student)
    {
        students.Add(student);
    }

    public void DisplayStudents()
    {
        foreach(var student in students)
        {
            Console.WriteLine($"Applicant ID : {student.ApplicantID}             ||             Name : {student.Name}             ||             Location : {student.Location}             ||             Preferred Location : {student.PrefLocation}             ||               Core : {student.Core}             ||             Passing Year : {student.PassingYear} ");

        }
    }
    public CampusHire SearchByID(string id)
    {
        return students.FirstOrDefault(p=> p.ApplicantID == id);
    }

    public void UpdateDetails(string id,string location)
    {
        var student = students.FirstOrDefault(p=> p.ApplicantID==id);
        if(student!=null)
        {
            student.Location=location;
        }
        Console.WriteLine("Data Updated Sucessfully!!!!!");
    }
    public void DeleteRecord(string id)
    {
        foreach(var student in students)
        {
            if(student.ApplicantID == id)
            {
                students.Remove(student);
                break;
                
            }
        }
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        Operations operations = new Operations();
        CampusHire student1 = new CampusHire("A001", "John Doe", "New York", "San Francisco", "Software Engineer", 2022);
        CampusHire student2 = new CampusHire("A002", "Jane Smith", "Los Angeles", "Seattle", "Data Scientist", 2023);

        operations.AddStudent(student1);
        operations.AddStudent(student2);
        Console.WriteLine("All Students:");
        operations.DisplayStudents();
        Console.WriteLine("\nSearch by ID (A001):");
        var searchResult = operations.SearchByID("A001");
        if (searchResult != null)
        {
            Console.WriteLine($"Found: {searchResult.Name} in {searchResult.Location}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
        Console.WriteLine("\nUpdating Location for A001 to 'Chicago'...");
        operations.UpdateDetails("A001", "Chicago");
        Console.WriteLine("\nAll Students after update:");
        operations.DisplayStudents();

        Console.WriteLine("\nDeleting record with ID A002...");
        operations.DeleteRecord("A002");

        Console.WriteLine("\nAll Students after deletion:");
        operations.DisplayStudents();
    }
}