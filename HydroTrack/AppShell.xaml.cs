using HydroTrack.Views;

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

            GoToAsync("//SplashView");
        }
    }
}
