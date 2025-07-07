using HydroTrack.ViewModels;

namespace HydroTrack.Views.SettingsViews;

public partial class SettingsView : ContentView
{
    public SettingsView(SettingsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}