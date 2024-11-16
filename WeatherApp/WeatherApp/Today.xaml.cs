using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;

using System.Net.Http.Json;


namespace WeatherApp;

public partial class Today : ContentPage
{


    public ObservableCollection<HourlyForecast> HourlyForecasts { get; set; }
    public WeatherData weather_data { get; set; }
    private Meteo_API Weather_API;
    public HourlyForecast SelectedHour { get; set; }

    public Today()
	{
		InitializeComponent();
        Weather_API = new Meteo_API();
        HourlyForecasts = new ObservableCollection<HourlyForecast>();
        weather_data = new WeatherData();
        LoadHourlyData();
        BindingContext = this;
    }


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
        Console.WriteLine(weather_data.lat);
    }

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

public class HourlyForecast : INotifyPropertyChanged
{
    public DateTime Time { get; set; }
    public float Temp { get; set; }

    private bool isSelected;

    public bool IsSelected
    {
        get => isSelected;
        set
        {
            isSelected = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}