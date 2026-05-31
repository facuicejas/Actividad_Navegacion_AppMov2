using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Parcial1Cejas.Services;
using Parcial1Cejas.ViewModels;
using Parcial1Cejas.Views;

namespace Parcial1Cejas
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont(
                        "OpenSans-Regular.ttf",
                        "OpenSansRegular");

                    fonts.AddFont(
                        "OpenSans-Semibold.ttf",
                        "OpenSansSemibold");
                });

            // Estos son los servicios que va a usar el programa
            builder.Services.AddSingleton<ApiService>();
            builder.Services.AddSingleton<NavigationService>();

            // Estos son los ViewModels del programa
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<DetailViewModel>();
            builder.Services.AddTransient<AddGameViewModel>();

            // Estas son las Views del programa
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<AddGamePage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}