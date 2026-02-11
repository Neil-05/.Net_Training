using System;
using System.Collections.Generic;
using System.Linq;

#region Core Contracts

public interface IPatient
{
    int PatientId { get; }
    string Name { get; }
    DateTime DateOfBirth { get; }
    BloodType BloodType { get; }
}

public enum BloodType { A, B, AB, O }
public enum Condition { Stable, Critical, Recovering }

#endregion

#region Priority Queue

public class PriorityQueue<T> where T : IPatient
{
    private SortedDictionary<int, Queue<T>> _queues = new();

    // 1 = highest, 5 = lowest
    public void Enqueue(T patient, int priority)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        if (priority < 1 || priority > 5)
            throw new ArgumentException("Priority must be between 1 and 5.");

        if (!_queues.ContainsKey(priority))
            _queues[priority] = new Queue<T>();

        _queues[priority].Enqueue(patient);
    }

    public T Dequeue()
    {
        if (!_queues.Any())
            throw new InvalidOperationException("Queue is empty.");

        foreach (var queue in _queues)
        {
            if (queue.Value.Count > 0)
                return queue.Value.Dequeue();
        }

        throw new InvalidOperationException("Queue is empty.");
    }

    public T Peek()
    {
        if (!_queues.Any())
            throw new InvalidOperationException("Queue is empty.");

        foreach (var queue in _queues)
        {
            if (queue.Value.Count > 0)
                return queue.Value.Peek();
        }

        throw new InvalidOperationException("Queue is empty.");
    }

    public int GetCountByPriority(int priority)
    {
        if (_queues.ContainsKey(priority))
            return _queues[priority].Count;

        return 0;
    }
}

#endregion

#region Medical Record

public class MedicalRecord<T> where T : IPatient
{
    private T _patient;
    private List<(DateTime date, string diagnosis)> _diagnoses = new();
    private Dictionary<DateTime, string> _treatments = new();

    public MedicalRecord(T patient)
    {
        _patient = patient;
    }

    public void AddDiagnosis(string diagnosis, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(diagnosis))
            throw new ArgumentException("Diagnosis cannot be empty.");

        _diagnoses.Add((date, diagnosis));
    }

    public void AddTreatment(string treatment, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(treatment))
            throw new ArgumentException("Treatment cannot be empty.");

        _treatments[date] = treatment;
    }

    public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
    {
        return _treatments.OrderBy(t => t.Key);
    }
}

#endregion

#region Specialized Patients

public class PediatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }

    public string GuardianName { get; set; }
    public double Weight { get; set; } // kg

    public override string ToString() => $"Pediatric: {Name}";
}

public class GeriatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }

    public List<string> ChronicConditions { get; } = new();
    public int MobilityScore { get; set; } // 1-10

    public override string ToString() => $"Geriatric: {Name}";
}

#endregion

#region Medication System

public class MedicationSystem<T> where T : IPatient
{
    private Dictionary<T, List<(string medication, DateTime time)>> _medications = new();

    public void PrescribeMedication(T patient, string medication,
        Func<T, bool> dosageValidator)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        if (!dosageValidator(patient))
        {
            Console.WriteLine($"Dosage validation failed for {patient.Name}");
            return;
        }

        if (!_medications.ContainsKey(patient))
            _medications[patient] = new List<(string, DateTime)>();

        _medications[patient].Add((medication, DateTime.Now));

        Console.WriteLine($"Medication {medication} prescribed to {patient.Name}");
    }

    public bool CheckInteractions(T patient, string newMedication)
    {
        if (!_medications.ContainsKey(patient))
            return false;

        // Simple mock interaction rule:
        // If already taking same medication → interaction
        return _medications[patient]
            .Any(m => m.medication.Equals(newMedication, StringComparison.OrdinalIgnoreCase));
    }
}

#endregion

#region Test Simulation

public class Program
{
    public static void Main()
    {
        // Create patients
        var child1 = new PediatricPatient
        {
            PatientId = 1,
            Name = "Tom",
            DateOfBirth = new DateTime(2018, 5, 1),
            BloodType = BloodType.O,
            GuardianName = "Sarah",
            Weight = 18
        };

        var child2 = new PediatricPatient
        {
            PatientId = 2,
            Name = "Emma",
            DateOfBirth = new DateTime(2016, 3, 10),
            BloodType = BloodType.A,
            GuardianName = "John",
            Weight = 22
        };

        var elder1 = new GeriatricPatient
        {
            PatientId = 3,
            Name = "Mr. Smith",
            DateOfBirth = new DateTime(1945, 1, 1),
            BloodType = BloodType.B,
            MobilityScore = 4
        };

        var elder2 = new GeriatricPatient
        {
            PatientId = 4,
            Name = "Mrs. Brown",
            DateOfBirth = new DateTime(1940, 7, 15),
            BloodType = BloodType.AB,
            MobilityScore = 6
        };

        // Priority Queue
        var queue = new PriorityQueue<IPatient>();

        queue.Enqueue(child1, 2);
        queue.Enqueue(child2, 1);
        queue.Enqueue(elder1, 3);
        queue.Enqueue(elder2, 1);

        Console.WriteLine("Next patient: " + queue.Dequeue().Name);

        // Medical Records
        var record1 = new MedicalRecord<IPatient>(child1);
        record1.AddDiagnosis("Flu", DateTime.Now.AddDays(-2));
        record1.AddTreatment("Antiviral", DateTime.Now.AddDays(-1));

        Console.WriteLine("\nTreatment History:");
        foreach (var t in record1.GetTreatmentHistory())
            Console.WriteLine($"{t.Key}: {t.Value}");

        // Medication System
        var medSystem = new MedicationSystem<IPatient>();

        // Pediatric weight-based validation
        medSystem.PrescribeMedication(child1, "Paracetamol",
            p => p is PediatricPatient ped && ped.Weight > 10);

        // Geriatric mobility validation
        medSystem.PrescribeMedication(elder1, "Aspirin",
            p => p is GeriatricPatient ger && ger.MobilityScore > 3);

        // Drug interaction check
        bool interaction = medSystem.CheckInteractions(child1, "Paracetamol");
        Console.WriteLine($"\nInteraction detected for Tom: {interaction}");
    }
}

#endregion
