using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient _http = new HttpClient();

    static async Task Main()
    {
        await FetchJsonAsync();
    }

    private static async Task FetchJsonAsync()
    {
        Console.WriteLine("Fetching...");

        try
        {
            string url = "https://www.google.com";
            string response = await _http.GetStringAsync(url);
            Console.WriteLine(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
