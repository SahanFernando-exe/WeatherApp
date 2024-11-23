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
    public HourlyForecast SelectedHour { get; set; }
    public ObservableCollection<WeatherData> HourlyForecasts { get; set; }

    public Today()
    {
        InitializeComponent();
        Weather_API = new Meteo_API();
        weather_data = new WeatherData();
        BindingContext = weather_data;
        FetchWeatherData();
        HourlyForecasts = new ObservableCollection<WeatherData>();
        //LoadHourlyData();
    }

    private async void FetchWeatherData()
    {
        weather_data = await Weather_API.GetWeatherDataAsync("gfas");
        BindingContext = weather_data;
    }









































    /*
    private async void LoadHourlyData()
    {
        weather_data = await Weather_API.GetWeatherDataAsync("gfas");
        // Sample data - replace with your actual weather API data
        var currentTime = DateTime.Now;
        for (int i = 0; i < 24; i++)
        {
            HourlyForecasts.Add(new HourlyForecast
            {
                Time = weather_data.hourly.time[i],
                Temp = weather_data.hourly.temp[i]
            });
        }
    }

    */




    private void OnHourSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is HourlyForecast selected)
        {
            SelectedHour = selected;
            OnPropertyChanged(nameof(SelectedHour));
        }
    }









    private void OnHourTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is HourlyForecast tappedHour)
        {
            Console.WriteLine("touched" + tappedHour.Time);
        }
    }
}







public class HourlyForecast
{
    public DateTime Time { get; set; }
    public float Temp { get; set; }
}