using HydroTrack.Services;
using HydroTrack.ViewModels;
using HydroTrack.Views;
using HydroTrack.Views.HomeViews;
using HydroTrack.Views.SettingsViews;
using Microsoft.Extensions.Logging;

namespace HydroTrack
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<SplashView>();

            builder.Services.AddTransient<LoginView>();
            builder.Services.AddTransient<LoginViewModel>();

            builder.Services.AddTransient<MainView>();
            builder.Services.AddTransient<MainViewModel>();

            builder.Services.AddTransient<SettingsView>();
            builder.Services.AddTransient<SettingsViewModel>();

            builder.Services.AddTransient<HomeView>();

            builder.Services.AddTransient<ChangePasswordView>();
            builder.Services.AddTransient<ChangePasswordViewModel>();

            builder.Services.AddSingleton<INavigationService, NavigationService>();

            return builder.Build();
        }
    }
}
