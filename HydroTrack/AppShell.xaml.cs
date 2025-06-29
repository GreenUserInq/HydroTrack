using HydroTrack.Views;
using HydroTrack.Views.SettingsViews;

namespace HydroTrack
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SplashView), typeof(SplashView));
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(MainView), typeof(MainView));
            Routing.RegisterRoute(nameof(SettingsView), typeof(SettingsView));
            Routing.RegisterRoute(nameof(ChangePasswordView), typeof(ChangePasswordView));

            GoToAsync("//SplashView");
        }
    }
}
