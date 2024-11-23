using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

using System.Runtime.CompilerServices;


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
                var current_parameters = "current=temperature_2m,apparent_temperature,cloud_cover,relative_humidity_2m,precipitation_probability,wind_speed_10m,wind_gusts_10m";
                var hourly_parameters = "hourly=temperature_2m,apparent_temperature,cloud_cover,relative_humidity_2m,precipitation_probability";
                var url = $"{_baseUrl}/forecast?latitude=-31.9522&longitude=115.8614&{current_parameters}&{hourly_parameters}";
                var response = await _httpClient.GetAsync(url);
                WeatherData weatherData = await response.Content.ReadFromJsonAsync<WeatherData>();
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

        public async Task<dynamic> GetSpecWeatherDataAsync(string location, string _params)
        {
            try
            {   // Build the URL with query parameters
                var url = $"{_baseUrl}/forecast?{location}&{_params}";

                // Make the API call
                var response = await _httpClient.GetAsync(url);

                // Check if the request was successful
                response.EnsureSuccessStatusCode();
                Console.WriteLine("#######################################_____________________________________________________successish");
                // Deserialize the JSON response
                dynamic weatherData = await response.Content.ReadFromJsonAsync<dynamic>();
                Console.WriteLine("#######################################_____________________________________________________success");
                return weatherData;
            }
            catch (HttpRequestException ex)
            {   // Handle specific HTTP errors
                Console.WriteLine("#######################################_____________________________________________________1");
                throw new Exception($"Error fetching weather data: {ex.Message}");
            }
            catch (JsonException ex)
            {   // Handle JSON parsing errors
                Console.WriteLine("#######################################_____________________________________________________2");
                throw new Exception($"Error parsing weather data: {ex.Message}");
            }
            catch (Exception ex)
            {   // Handle any other unexpected errors\
                Console.WriteLine("#######################################_____________________________________________________3");
                throw new Exception($"Unexpected error: {ex.Message}");
            }
        }
    }
}
