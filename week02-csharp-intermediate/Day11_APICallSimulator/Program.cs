namespace ApiCallSimulator
{
  using System;
  using System.Net.Http;
  using System.Threading.Tasks;

  class Program
  {
    static async Task Main(string[] args)
    {
      Console.WriteLine("=== API Call Simulator ===");
      string apiUrl = "https://google.com"; // Example API endpoint

      try
      {
        using HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(apiUrl);
        response.EnsureSuccessStatusCode();

        var responseCode = (int)response.StatusCode;
        Console.WriteLine($"API-aanroep Response code: {responseCode}");
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine($"Fout bij het maken van de API-aanroep: {e.Message}");
      }
    }
  }
}
