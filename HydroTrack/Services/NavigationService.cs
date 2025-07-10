using HydroTrack.ViewModels;
using HydroTrack.ViewModels.CoreViewModels;
using HydroTrack.ViewModels.HomeViewModels;
using HydroTrack.ViewModels.SettingsViewModels;
using HydroTrack.Views.CoreViews;
using HydroTrack.Views.HomeViews;
using HydroTrack.Views.SettingsViews;

namespace HydroTrack.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Func<MainViewModel> _mainViewModelFactory;
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(Func<MainViewModel> mainViewModelFactory,  IServiceProvider serviceProvider)
        {
            _mainViewModelFactory = mainViewModelFactory;
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo(ContentView view)
        {
            _mainViewModelFactory().CurrentView = view;
        }

        public void NavigateToChangePassword()
        {
            var vm = _serviceProvider.GetRequiredService<ChangePasswordViewModel>();
            var view = new ChangePasswordView(vm);
            NavigateTo(view);
        }

        public void NavigateToSettings()
        {
            var vm = _serviceProvider.GetRequiredService<SettingsViewModel>();
            var view = new SettingsView(vm);
            NavigateTo(view);
        }

        public void NavigateToHome()
        {
            var vm = _serviceProvider.GetRequiredService<HomeViewModel>();
            var view = new HomeView(vm);
            NavigateTo(view);
        }
        public void NavigateToSystems()
        {
            var vm = _serviceProvider.GetRequiredService<SystemsViewModel>();
            var view = new SystemsView(vm);
            NavigateTo(view);
        }

        public void NavigateToConnectionSettings()
        {
            var vm = _serviceProvider.GetRequiredService<ConnectionSetingsViewModel>();
            var view = new ConnectionSettingsView(vm);
            NavigateTo(view);
        }
    }
}
