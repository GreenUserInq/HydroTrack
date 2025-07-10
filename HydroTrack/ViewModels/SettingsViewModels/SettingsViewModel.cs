using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HydroTrack.Services;
using HydroTrack.ViewModels.Base;
using System.Threading.Tasks;

namespace HydroTrack.ViewModels
{
    public partial class SettingsViewModel : NavigableViewModel
    {
        public SettingsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        [RelayCommand]
        private void OpenChangePassword()
        {
            NavigationService.NavigateToChangePassword();
        }

        [RelayCommand]
        private void OpenConnectionSettings()
        {
            NavigationService.NavigateToConnectionSettings();
        }
    }
}
