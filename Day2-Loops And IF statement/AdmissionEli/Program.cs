class AdmissionEligibility
{
    public static void Main(string[] args)
    {   Console.WriteLine("Enter marks in Mathematics, Physics and Chemistry:");
        int math = int.Parse(Console.ReadLine()!);
        int phys = int.Parse(Console.ReadLine()!);
        int chem = int.Parse(Console.ReadLine()!);

        int total = math + phys + chem;

        if (math >= 65 && phys >= 55 && chem >= 50 &&
            (total >= 180 || (math + phys) >= 140))
        {
            Console.WriteLine("Eligible for Admission");
        }
        else
        {
            Console.WriteLine("Not Eligible for Admission");
        }
    }
}