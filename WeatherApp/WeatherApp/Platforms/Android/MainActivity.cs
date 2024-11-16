using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace WeatherApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Make the app fullscreen
            Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
        }
    }
}
