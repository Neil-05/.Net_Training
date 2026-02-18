class HeightCategory
{
    public static void Main(string[] args)
    {
        int height = int.Parse(Console.ReadLine());

        if (height < 150)
            Console.WriteLine("Dwarf");
        else if (height <= 165)
            Console.WriteLine("Average");
        else if (height <= 190)
            Console.WriteLine("Tall");
        else
            Console.WriteLine("Abnormal");
    }
}