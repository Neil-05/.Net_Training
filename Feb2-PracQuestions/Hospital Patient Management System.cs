using System;
using System.Collections.Generic;
using System.Linq;

class Patient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string BloodGroup { get; set; }
    public List<string> MedicalHistory { get; set; } = new List<string>();
}

class Doctor
{
    public int DoctorId { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public List<DateTime> AvailableSlots { get; set; } = new List<DateTime>();
}

class Appointment
{
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentTime { get; set; }
    public string Status { get; set; }
}

class HospitalManager
{
    private List<Patient> patients = new List<Patient>();
    private List<Doctor> doctors = new List<Doctor>();
    private List<Appointment> appointments = new List<Appointment>();

    private int pCounter = 1;
    private int dCounter = 1;
    private int aCounter = 1;

    public void AddPatient(string name, int age, string blood)
    {
        patients.Add(new Patient
        {
            PatientId = pCounter++,
            Name = name,
            Age = age,
            BloodGroup = blood
        });
    }

    public void AddDoctor(string name, string spec)
    {
        doctors.Add(new Doctor
        {
            DoctorId = dCounter++,
            Name = name,
            Specialization = spec
        });
    }

    public bool ScheduleAppointment(int pid, int did, DateTime time)
    {
        var p = patients.FirstOrDefault(x => x.PatientId == pid);
        var d = doctors.FirstOrDefault(x => x.DoctorId == did);

        if (p == null || d == null) return false;

        appointments.Add(new Appointment
        {
            AppointmentId = aCounter++,
            PatientId = pid,
            DoctorId = did,
            AppointmentTime = time,
            Status = "Scheduled"
        });

        return true;
    }

    public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
    {
        return doctors.GroupBy(d => d.Specialization)
                      .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Appointment> GetTodayAppointments()
    {
        return appointments.Where(a =>
            a.AppointmentTime.Date == DateTime.Today).ToList();
    }
}

class Program
{
    static void Main()
    {
        HospitalManager manager = new HospitalManager();

        manager.AddPatient("Mukesh", 22, "O+");
        manager.AddPatient("Amit", 30, "B+");

        manager.AddDoctor("Dr Sharma", "Cardiology");
        manager.AddDoctor("Dr Verma", "Orthopedic");

        manager.ScheduleAppointment(1, 1, DateTime.Today.AddHours(10));
        manager.ScheduleAppointment(2, 2, DateTime.Today.AddHours(12));

        Console.WriteLine("Doctors By Specialization:");

        var docs = manager.GroupDoctorsBySpecialization();

        foreach (var g in docs)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var d in g.Value)
                Console.WriteLine(d.Name);
        }

        Console.WriteLine("\nToday's Appointments:");

        foreach (var a in manager.GetTodayAppointments())
            Console.WriteLine("Patient " + a.PatientId +
                              " with Doctor " + a.DoctorId);
    }
}
