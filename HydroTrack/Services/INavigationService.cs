namespace HydroTrack.Services
{
    public interface INavigationService
    {
        void NavigateTo(ContentView view);

        void NavigateToChangePassword();
        void NavigateToSettings();
        void NavigateToHome();
        void NavigateToSystems();
        void NavigateToConnectionSettings();
    }
}
