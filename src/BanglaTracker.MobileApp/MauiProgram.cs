using BanglaTracker.BLL.Services;
using BanglaTracker.Infrastructure.Services;
using BanglaTracker.Presentation.ViewModels;
using BanglaTracker.Presentation.Views;
using Microsoft.Extensions.Logging;

namespace BanglaTracker.MobileApp
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
                });

            // Register HttpClient and TrainPointService
            builder.Services.AddHttpClient<LocationService>(client =>
            {
                client.BaseAddress = new Uri("https://api.example.com/");
            });

            // Register AppShell as a singleton
            builder.Services.AddSingleton<AppShell>();

            // Register your services, view models, and pages here
            builder.Services.AddSingleton<MainPage>();

            
            builder.Services.AddSingleton<TrainPointService>();
            builder.Services.AddTransient<TrainLocationPage1>();


            // Register pages and view models
            builder.Services.AddTransient<TrainLocationPage>();
            builder.Services.AddTransient<TrainLocationViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
