using System;

// Step 1: Declare delegate (class ke andar, method ke bahar)
public delegate int DelegateAddFunctionName(int a, int b);

public class MainClass
{
    // Step 2: Method jo delegate se match karta ho
    public static int AddMethod1(int a, int b)
    {
        return a + b;
    }

    // Step 3: Main method (Entry Point)
    public static void Main(string[] args)
    {
        // Step 4: Delegate object create + method assign
        DelegateAddFunctionName delegatevar= new DelegateAddFunctionName(AddMethod2);

        // Step 5: Delegate call
      int  result= delegatevar(1,2);

        

        Console.WriteLine("Addition Result: " + result);
    }
    private static int AddMethod2(int a, int b)
    {
        return a+b+40;
    }
}