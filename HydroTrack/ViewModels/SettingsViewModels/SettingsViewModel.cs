using CommunityToolkit.Mvvm.ComponentModel;
using HydroTrack.Views;
using System.Windows.Input;

namespace HydroTrack.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        public ICommand PasswordChange {  get;}
        public ICommand GoMain { get;}

        [ObservableProperty]
        private int width;

        public SettingsViewModel()
        {
            PasswordChange = new Command(ChangePass);
            GoMain = new Command(showMain);
            width = 0;
        }

        private async void showMain()
        {
            try
            {
                await Shell.Current.GoToAsync("\\MainView");
            }
            catch (Exception e)
            {

                await Shell.Current.DisplayAlert("Ошибка", $"{e.ToString()}", "ОК");
            }
        }

        private async void ChangePass()
        {
            try
            {
                await Shell.Current.GoToAsync("\\ChangePasswordView");
            }
            catch (Exception e)
            {

                await Shell.Current.DisplayAlert("Ошибка", $"{e.ToString()}", "ОК");
            }
        }
    }
}
