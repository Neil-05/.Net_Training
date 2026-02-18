using System;
using System.Collections;

public class BigBoy : IDisposable
{
    public ArrayList Names { get; set; }

    public BigBoy()
    {
        Names = new ArrayList();
    }

    public void Dispose()
    {
        Names = null; // releasing reference
        Console.WriteLine("Resources disposed");
    }
}
public class Program
{
    static void Main()
    {
        BigBoy bigb = new BigBoy();

        try
        {
            for (int i = 0; i < 10; i++)
            {
                bigb.Names.Add(i.ToString());
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            bigb.Dispose(); // guaranteed cleanup
        }
    }
}
