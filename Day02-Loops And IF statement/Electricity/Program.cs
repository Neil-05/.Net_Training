using System;

class ElectricityBill
{
    public static void Main(string[] args)
    {   Console.WriteLine("Enter the number of units consumed:");
        int units = int.Parse(Console.ReadLine()!);
        double bill;

        if (units <= 199)
            bill = units * 1.20;
        else if (units <= 400)
            bill = 199 * 1.20 + (units - 199) * 1.50;
        else if (units <= 600)
            bill = 199 * 1.20 + 201 * 1.50 + (units - 400) * 1.80;
        else
            bill = 199 * 1.20 + 201 * 1.50 + 200 * 1.80 + (units - 600) * 2.00;

        if (bill > 400)
            bill += bill * 0.15;

        Console.WriteLine("Electricity Bill = " + bill);
    }
}
