using HydroTrack.ViewModels;

namespace HydroTrack.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Func<MainViewModel> _mainViewModelFactory;

        public NavigationService(Func<MainViewModel> mainViewModelFactory)
        {
            _mainViewModelFactory = mainViewModelFactory;
        }

        public void NavigateTo(ContentView view)
        {
            _mainViewModelFactory().CurrentView = view;
        }
    }
}
