using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;

using System.Net.Http.Json;


namespace WeatherApp;

public partial class Today : ContentPage
{
    public WeatherData weather_data { get; set; }
    private Meteo_API Weather_API;

    public Today()
    {
        InitializeComponent();
        Weather_API = new Meteo_API();
        weather_data = new WeatherData();
        BindingContext = weather_data;
        FetchWeatherData();
    }

    private async void FetchWeatherData()
    {
        weather_data = await Weather_API.GetWeatherDataAsync("gfas");
        BindingContext = weather_data;
    }
}