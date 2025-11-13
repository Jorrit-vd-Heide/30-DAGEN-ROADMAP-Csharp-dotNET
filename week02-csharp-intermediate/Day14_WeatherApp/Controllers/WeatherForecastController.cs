using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq; // Voeg dit toe
using System.Net.Http; // Voor HttpClient
using System.Threading.Tasks;

namespace Day14_WeatherApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public WeatherForecastController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpGet("external", Name = "GetExternalWeatherData")]
    public async Task<IActionResult> GetExternalWeatherData([FromQuery] string location)
    {
        //string location = "Nieuwehorne, FR, NL";
        string apiKey = "YMJVAUWFMDHAY26KR9489XG6Y";
        string url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{Uri.EscapeDataString(location)}?unitGroup=metric&include=days,hours,current&key={apiKey}&contentType=json";

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Gooit fout als niet succesvol

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject weatherData = JObject.Parse(responseBody);

            // Eventueel wat data eruit halen
            var current = weatherData["currentConditions"];
            var result = new
            {
                Location = location,
                CurrentTemp = current?["temp"]?.ToString(),
                Conditions = current?["conditions"]?.ToString(),
                Forecast = weatherData["days"]?.Select(day => new
                {
                    Date = day?["datetime"]?.ToString(),
                    MaxTemp = day?["tempmax"]?.ToString(),
                    MinTemp = day?["tempmin"]?.ToString(),
                    Conditions = day?["conditions"]?.ToString()
                })
            };

            // Geef JSON terug aan de client
            return Ok(result);
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, $"Error fetching weather data: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Unexpected error: {ex.Message}");
        }
    }
}
