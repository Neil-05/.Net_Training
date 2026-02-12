public class Program
{
    public static void Main(string[] args)
    {
        string input= Console.ReadLine();
        string rev="";
        bool flag =true;
        for(int i=input.Length-1;i>=0;i--)
        {
            rev+=input[i];
        }
        for(int i=0;i<input.Length;i++)
        {
            if( input[i] != rev[i])
                flag=false;
        }
        if(flag) Console.WriteLine("Palindrome");
        else
        Console.WriteLine("Not a Paindrome");
    }
}