using BanglaTracker.BLL.Interfaces;
using BanglaTracker.BLL.Services;
using BanglaTracker.Core.Interfaces;
using BanglaTracker.Infrastructure.Data.Repositories;
using BanglaTracker.Infrastructure.Services;
using BanglaTracker.Presentation.ViewModels;
using BanglaTracker.Presentation.Views;
using Microsoft.Extensions.Logging;
using SQLite;

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

            // Configure Database
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "BanglaTrackerClient.db");

            // Register the SQLite connection
            builder.Services.AddSingleton(new SQLiteAsyncConnection(dbPath));

            // Register the generic repository for scoped lifetime
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Register HttpClient and LocationService
            builder.Services.AddHttpClient<ILocationService, LocationService>()
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
                    };
                });

            // Register AppShell as a singleton
            builder.Services.AddSingleton<AppShell>();

            // Register your services, view models, and pages here
            builder.Services.AddSingleton<MainPage>();

            
            builder.Services.AddSingleton<ITrainPointService, TrainPointService>();
            builder.Services.AddSingleton<IUserService, UserService>();

            builder.Services.AddTransient<TrainLocationPage1>();


            // Register pages and view models
            builder.Services.AddTransient<TrainLocationPage>();
            builder.Services.AddTransient<TrainLocationViewModel>();

            builder.Services.AddSingleton<JourneyActivationPage>();
            builder.Services.AddTransient<JourneySearchPage>();

            builder.Services.AddTransient<JourneyDetailViewModel>();
            builder.Services.AddTransient<TwoStationsDetailPage>();

            builder.Services.AddTransient<AllStationsDetailViewModel>();
            builder.Services.AddTransient<AllStationsDetailPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
