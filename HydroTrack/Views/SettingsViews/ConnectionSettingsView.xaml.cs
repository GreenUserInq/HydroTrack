using HydroTrack.ViewModels.SettingsViewModels;

namespace HydroTrack.Views.SettingsViews;

public partial class ConnectionSettingsView : ContentView
{
	public ConnectionSettingsView(ConnectionSetingsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}