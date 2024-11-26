namespace WeatherApp;

public partial class ThisWeek : ContentPage
{
    private WeatherData weather_data { get; set; }
    private Meteo_API Weather_API;

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Weather_API = new Meteo_API();
        weather_data = new WeatherData();
        weather_data = await Weather_API.GetWeatherDataAsync("gfas");
        BindingContext = weather_data;
    }

    public ThisWeek()
	{
		InitializeComponent();
    }

    private void ToNet(object sender, EventArgs e)
    {

    }

    private void ToToday(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Today());
    }

    private async void ToSettings(object sender, EventArgs e)
    {

    }
}