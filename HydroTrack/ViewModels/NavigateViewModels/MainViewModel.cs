using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HydroTrack.Views.HomeViews;
using HydroTrack.Views.SettingsViews;
using System.Windows.Input;

namespace HydroTrack.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private View? currentView;

    public ICommand MenuSelectCommand { get; }

    private readonly IServiceProvider _serviceProvider;

    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        CurrentView = _serviceProvider.GetService<HomeView>();
        MenuSelectCommand = new RelayCommand<string>(OnMenuSelected);
    }

    private void OnMenuSelected(string selected)
    {
        CurrentView = selected switch
        {
            "Home" => _serviceProvider.GetService<HomeView>(),
            "Settings" => _serviceProvider.GetService<SettingsView>(),
            "Pass" => _serviceProvider.GetService<ChangePasswordView>(),
            _ => null
        };
    }
}
