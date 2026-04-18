using System;
class MessageEncoder
{
public string encodeMessage(string message)
{
    if(message.Length<4) return $"The string {message} has minimum length";
    if(message.Contains(" ")) return $"The string {message} should not contain a space";
    string x="";
    for(int i=0;i<message.Length;i++)
        {
            int ch=(int)message[i]-10;
            
            x+=(char)ch;
        }
    return x;
}
}
class UserInterface
{
public static void Main()
    {
        MessageEncoder mess=new MessageEncoder();
        Console.WriteLine(mess.encodeMessage("HelloWorld"));
    }


}

