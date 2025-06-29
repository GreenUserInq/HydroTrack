using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HydroTrack.ViewModels
{
    public partial class ChangePasswordViewModel : ObservableObject
    {
        private readonly string passwordFilePath = Path.Combine(FileSystem.AppDataDirectory, "password.txt");

        [ObservableProperty]
        private string currentPassword;

        [ObservableProperty]
        private string newPassword;

        [ObservableProperty]
        private string confirmPassword;

        [ObservableProperty]
        private string statusMessage;

        public ICommand GoMain { get; }
        public ICommand GoBack { get; }

        public ChangePasswordViewModel()
        {
            GoMain = new Command(showMain);
            GoBack = new Command(showSettings);
            // Если файла с паролем ещё нет — создаём со стандартным значением
            if (!File.Exists(passwordFilePath))
            {
                File.WriteAllText(passwordFilePath, "1234"); // Начальный пароль
            }
        }

        private async void showSettings()
        {
            try
            {
                await Shell.Current.GoToAsync("//SettingsView");
            }
            catch (Exception e)
            {

                await Shell.Current.DisplayAlert("Ошибка", $"{e.ToString()}", "ОК");
            }
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

        [RelayCommand]
        public async Task ChangePasswordAsync()
        {
            Debug.WriteLine("=== КОМАНДА ChangePasswordAsync ВЫЗВАНА ===");
            try
            {
                string savedPassword = File.ReadAllText(passwordFilePath);

                if (CurrentPassword != savedPassword)
                {
                    StatusMessage = "Текущий пароль неверный.";
                    return;
                }

                if (string.IsNullOrWhiteSpace(NewPassword))
                {
                    StatusMessage = "Новый пароль не может быть пустым.";
                    return;
                }

                if (NewPassword != ConfirmPassword)
                {
                    StatusMessage = "Новый пароль и подтверждение не совпадают.";
                    return;
                }

                File.WriteAllText(passwordFilePath, NewPassword);
                StatusMessage = "Пароль успешно изменён.";

                // Очистка полей
                CurrentPassword = string.Empty;
                NewPassword = string.Empty;
                ConfirmPassword = string.Empty;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Ошибка: {ex.Message}";
            }
        }
    }
}
