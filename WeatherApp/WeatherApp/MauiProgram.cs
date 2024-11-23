using Microsoft.Extensions.Logging;

namespace WeatherApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("AmericanCaptain.otf", "American");
                    fonts.AddFont("CaviarDreams.ttf", "CaviarDreams");
                    fonts.AddFont("CaviarDreams_Italic.ttf", "CaviarDreamsI");
                    fonts.AddFont("CaviarDreams_Bold.ttf", "CaviarDreamsB");
                    fonts.AddFont("Exo-Black.otf", "exob");
                    fonts.AddFont("Exo-Light.otf", "exol");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
