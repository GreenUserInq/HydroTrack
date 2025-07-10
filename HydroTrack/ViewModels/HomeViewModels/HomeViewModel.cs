using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        private readonly INavigationService _navigationService;

        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void OpenSettings()
        {
            _navigationService.NavigateToSettings();
        }
        [RelayCommand]
        private void OpenSystems()
        {
            _navigationService.NavigateToSystems();
        }
    }
}