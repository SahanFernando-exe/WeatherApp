namespace WeatherApp;

public partial class Today : ContentPage
{
    private WeatherData weather_data { get; set; }
    private Meteo_API Weather_API;

    public Today()
    {
        InitializeComponent();
        LoadData();
    }

    private async Task LoadData()
    {
        Weather_API = new Meteo_API();
        weather_data = new WeatherData();
        weather_data = await Weather_API.GetWeatherDataAsync("gfas");
        BindingContext = weather_data;
    }

    private void ToNet(object sender, EventArgs e)
    {

    }

    private void ToWeek(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ThisWeek());
    }

    private async void ToSettings(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Settings());
    }

}