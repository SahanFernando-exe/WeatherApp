namespace WeatherApp;

public partial class ThisWeek : ContentPage
{
    private WeatherData weather_data { get; set; }
    private Meteo_API Weather_API;
    public ThisWeek(WeatherData wdata)
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