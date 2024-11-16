using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;

using System.Net.Http.Json;


namespace WeatherApp;

public partial class Today : ContentPage
{


    public ObservableCollection<HourlyForecast> HourlyForecasts { get; set; }

    private Meteo_API Weather_API;
    public HourlyForecast SelectedHour { get; set; }

    public Today()
	{
		InitializeComponent();
        Weather_API = new Meteo_API();
        HourlyForecasts = new ObservableCollection<HourlyForecast>();
        LoadHourlyData();
        BindingContext = this;
    }


    private async void LoadHourlyData()
    {
        WeatherData dats = await Weather_API.GetWeatherDataAsync("gfas");
        // Sample data - replace with your actual weather API data
        var currentTime = DateTime.Now;
        for (int i = 0; i < 24; i++)
        {
            HourlyForecasts.Add(new HourlyForecast
            {
                Time = dats.hourly.time[i],
                Temperature = dats.hourly.temp[i],
                WeatherIcon = "sunny.png", // Replace with actual weather icon
                Description = $"Weather details for {currentTime.AddHours(i):HH:mm}"
            });
        }
        Console.WriteLine(dats.lat);
        TestingLabel.Text = dats.current.temp.ToString();
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
            // Handle tap event if needed
        }
    }
}

public class HourlyForecast : INotifyPropertyChanged
{
    public DateTime Time { get; set; }
    public double Temperature { get; set; }
    public string WeatherIcon { get; set; }
    public string Description { get; set; }
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