using HydroTrack.ViewModels;

namespace HydroTrack.Services
{
    public class NavigationService : INavigationService
    {
        private readonly MainViewModel _mainViewModel;

        public NavigationService(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void NavigateTo(ContentView view)
        {
            _mainViewModel.CurrentView = view;
        }
    }
}
