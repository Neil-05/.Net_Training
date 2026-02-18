using System.Reflection.Metadata;

public class s
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a string:");
        string n=Console.ReadLine();
        string rev= "";
        Dictionary<char,int> hashMap = new Dictionary<char,int>();
        foreach(char item in n)
        {
            if(item == ' ') continue;
            if(hashMap.ContainsKey(item))
            {
                hashMap[item] = hashMap[item]+1;
            }
            else
            {
                hashMap.Add(item,1);
            }      
        }
        Console.WriteLine("Frequency of characters in the string:");
        foreach(var item in hashMap)        {
            Console.WriteLine(item.Key+" : "+item.Value);
        
        // Console.WriteLine("Reverse of the string is:"+rev);
    }
}}






