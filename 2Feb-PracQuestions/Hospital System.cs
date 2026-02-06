class Patient
{
    public int PatientId;
    public string Name;
    public int Age;
    public string BloodGroup;
    public List<string> History = new();
}

class Doctor
{
    public int DoctorId;
    public string Name;
    public string Specialization;
}

class Appointment
{
    public int AppointmentId;
    public int PatientId;
    public int DoctorId;
    public DateTime Time;
    public string Status;
}

class HospitalManager
{
    List<Patient> patients = new();
    List<Doctor> doctors = new();
    List<Appointment> apps = new();

    int pid = 1, did = 1, aid = 1;

    public void AddPatient(string n, int a, string b)
    {
        patients.Add(new Patient { PatientId = pid++, Name = n, Age = a, BloodGroup = b });
    }

    public void AddDoctor(string n, string s)
    {
        doctors.Add(new Doctor { DoctorId = did++, Name = n, Specialization = s });
    }

    public bool ScheduleAppointment(int p, int d, DateTime t)
    {
        apps.Add(new Appointment { AppointmentId = aid++, PatientId = p, DoctorId = d, Time = t, Status = "Scheduled" });
        return true;
    }

    public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
    {
        return doctors.GroupBy(x => x.Specialization)
                      .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Appointment> GetTodayAppointments()
    {
        return apps.Where(x => x.Time.Date == DateTime.Today).ToList();
    }
}
