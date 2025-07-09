using CommunityToolkit.Mvvm.ComponentModel;
using HydroTrack.Services;
using HydroTrack.Views.SettingsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HydroTrack.ViewModels.HomeViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        public ICommand OpenSettingsCommand { get; }

        private INavigationService _navigationService;
        private IServiceProvider _serviceProvider;

        public HomeViewModel(INavigationService navigationService, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _navigationService = navigationService;

           OpenSettingsCommand = new Command(OpenSettings);
        }

        private void OpenSettings()
        {
            var settingsView = _serviceProvider.GetService<SettingsView>();

            if (settingsView != null)
            {
                _navigationService.NavigateTo(settingsView);
            }
        }
    }
}
