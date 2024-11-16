using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherApp
{
    public class Meteo_API
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public Meteo_API()
        {
            _httpClient = new HttpClient();
            _baseUrl = "https://api.open-meteo.com/v1";

            // Set default headers if needed
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<WeatherData> GetWeatherDataAsync(string city)
        {
            try
            {
                // Build the URL with query parameters
                var url = $"{_baseUrl}/forecast?latitude=-31.9522&longitude=115.8614&current=temperature_2m,relative_humidity_2m,apparent_temperature,precipitation,rain&hourly=temperature_2m,relative_humidity_2m,apparent_temperature,precipitation_probability,precipitation";
                Console.WriteLine("#######################################_____________________________________________________jchbsdnmbvsmjhgekjhcvjksvdlsbdjklah");

                // Make the API call
                var response = await _httpClient.GetAsync(url);

                // Check if the request was successful
                response.EnsureSuccessStatusCode();
                Console.WriteLine("#######################################_____________________________________________________successish");
                // Deserialize the JSON response
                WeatherData weatherData = await response.Content.ReadFromJsonAsync<WeatherData>();
                Console.WriteLine("#######################################_____________________________________________________success");
                return weatherData;
            }
            catch (HttpRequestException ex)
            {
                // Handle specific HTTP errors
                Console.WriteLine("#######################################_____________________________________________________1");
                throw new Exception($"Error fetching weather data: {ex.Message}");
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing errors
                Console.WriteLine("#######################################_____________________________________________________2");
                throw new Exception($"Error parsing weather data: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected errors\
                Console.WriteLine("#######################################_____________________________________________________3");
                throw new Exception($"Unexpected error: {ex.Message}");
            }
        }

    }

    // Data models to match your API response
    public class WeatherData
    {
        [JsonPropertyName("latitude")]
        public float lat { get; set; }

        [JsonPropertyName("longitude")]
        public float lon { get; set; }

        [JsonPropertyName("current_units")]
        public CurrentUnits current_units { get; set; }

        [JsonPropertyName("current")]
        public Current current { get; set; }

        [JsonPropertyName("hourly_units")]
        public HourlyUnits hourly_units { get; set; }

        [JsonPropertyName("hourly")]
        public Hourly hourly { get; set; }
    }

    public class CurrentUnits
    {
        public string time { get; set; }
        public string interval { get; set; }
        public string temp { get; set; }
        public string humidity { get; set; }
        public string app_temp { get; set; }
        public string precip { get; set; }
        public string rain { get; set; }
    }

    public class Current
    {
        public string time { get; set; }
        public int interval { get; set; }

        [JsonPropertyName("temperature_2m")]
        public float temp { get; set; }
        public float humidity { get; set; }
        public float app_temp { get; set; }
        public float precip { get; set; }
        public float rain { get; set; }
    }

    public class HourlyUnits
    {
        public string time { get; set; }
        public string temp { get; set; }
        public string humidity { get; set; }
        public string app_temp { get; set; }
        public string precip { get; set; }
        public string rain { get; set; }
    }

    public class Hourly
    {
        public List<DateTime> time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<float> temp { get; set; }
        public List<float> humidity { get; set; }
        public List<float> app_temp { get; set; }
        public List<float> precip { get; set; }
        public List<float> rain { get; set; }
    }
}
