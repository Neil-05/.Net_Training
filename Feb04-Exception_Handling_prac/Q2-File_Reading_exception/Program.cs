class FileReader
{
    static void Main()
    {
        string filePath = "data.txt";

    
        try
        {
            string content = System.IO.File.ReadAllText(filePath);
            Console.WriteLine("File content:");
            Console.WriteLine(content);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine($"Error: The file '{filePath}' was not found.");
        }
        catch (System.UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Error: You do not have permission to access the file '{filePath}'.");
        }
        finally
        {
            Console.WriteLine("File read attempt completed.");
        }
    }
}