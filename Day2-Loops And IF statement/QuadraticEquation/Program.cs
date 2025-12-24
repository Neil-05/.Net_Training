class QuadraticEquation
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter coefficients a, b and c:");
        double a = double.Parse(Console.ReadLine()!);
        double b = double.Parse(Console.ReadLine()!);
        double c = double.Parse(Console.ReadLine()!);

        double d = b * b - 4 * a * c;

        if (d > 0)
        {
            double r1 = (-b + Math.Sqrt(d)) / (2 * a);
            double r2 = (-b - Math.Sqrt(d)) / (2 * a);
            Console.WriteLine("Two distinct real roots:");
            Console.WriteLine(r1);
            Console.WriteLine(r2);
        }
        else if (d == 0)
        {
            double r = -b / (2 * a);
            Console.WriteLine("One real root:");
            Console.WriteLine(r);
        }
        else
        {
            Console.WriteLine("No real roots");
        }
    }
}
