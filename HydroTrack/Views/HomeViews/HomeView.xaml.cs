using HydroTrack.ViewModels.HomeViewModels;

namespace HydroTrack.Views.HomeViews;

public partial class HomeView : ContentView
{
	public HomeView(HomeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

        SettingsButton.Pressed += async (s, e) =>
        await SettingsButton.ScaleTo(0.9, 100);

        SettingsButton.Released += async (s, e) =>
        await SettingsButton.ScaleTo(1, 100);
    }
}