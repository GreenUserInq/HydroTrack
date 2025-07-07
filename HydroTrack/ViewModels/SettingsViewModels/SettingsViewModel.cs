using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HydroTrack.Services;
using HydroTrack.ViewModels.Base;
using HydroTrack.Views;
using System.Windows.Input;

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
            //NavigationService.NavigateTo(new ChangePasswordView());
        }
    }
}
