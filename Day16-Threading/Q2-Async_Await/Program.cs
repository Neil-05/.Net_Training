public class ThreadingExample
{
    public static async Task AsyncMethod()
    {
        Console.WriteLine("Async Method Started");
        await Task.Delay(3000); // Simulate async work
        Console.WriteLine("Async Method Completed");
    }

    public async  void CallMethod()
    {
        string result =await FetchDataAsync("https://jsonplaceholder.typicode.com/todos");
        Console.WriteLine(result);
        await AsyncMethod();
    }
    public static async Task<string> FetchDataAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync(url);
            return response;
        }
    }
    public static void Main()
    {
        ThreadingExample example = new ThreadingExample();
        example.CallMethod();
        Console.WriteLine("Main Method Completed");
        Console.ReadLine(); // Keep the console open
    }
}
