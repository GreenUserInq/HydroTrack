using CommunityToolkit.Mvvm.ComponentModel;
using HydroTrack.Views;
using System.Diagnostics;
using System.Windows.Input;

namespace HydroTrack.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string password;

        public ICommand LoginCommand { get; }

        private readonly string passwordFilePath = Path.Combine(FileSystem.AppDataDirectory, "password.txt");

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private async void OnLogin()
        {

            try
            {
                if (!File.Exists(passwordFilePath))
                {
                    File.WriteAllText(passwordFilePath, "1234");
                }

                string savedPass = File.ReadAllText(passwordFilePath).Trim();

                if (Password == savedPass)
                {
                    await Shell.Current.GoToAsync("//MainView");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Неверный пароль", "ОК");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка при входе: {ex.Message}");
                await Shell.Current.DisplayAlert("Ошибка", "Не удалось проверить пароль", "ОК");
            }
        }
    }
}
