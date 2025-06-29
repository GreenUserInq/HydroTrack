using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using HydroTrack.Views;
using System.Windows.Input;

namespace HydroTrack.ViewModels
{
    
    public partial class MainViewModel : ObservableObject
    {
        public ICommand SettingsCommand { get; }
        public MainViewModel()
        {
            SettingsCommand = new Command(OpenSettings);
        }

        private async void OpenSettings()
        {
            await Shell.Current.GoToAsync("//SettingsView");
        }
    }
}
