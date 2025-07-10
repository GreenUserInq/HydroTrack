using HydroTrack.ViewModels.HomeViewModels;

namespace HydroTrack.Views.HomeViews;

public partial class HomeView : ContentView
{
	public HomeView(HomeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

        SetAnimationButton();

        bool isDesktop = DeviceInfo.Current.Platform == DevicePlatform.WinUI ||
                 DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst;

        if (!isDesktop)
        {
            // Изменяем ширину колонок: левая 100*, правая 0*
            var grid = (Grid)Content;
            grid.ColumnDefinitions[0].Width = new GridLength(100, GridUnitType.Star);
            grid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Star);
        }
    }

    private void SetAnimationButton()
    {
        SettingsButton.Pressed += async (s, e) =>
        {
            await Task.WhenAll(
                SettingsButton.ScaleTo(0.9, 100),
                SettingsButton.RotateTo(50, 100)
            );
        };

        SettingsButton.Released += async (s, e) =>
        {
            await Task.WhenAll(
                SettingsButton.ScaleTo(1, 100),
                SettingsButton.RotateTo(0, 100)
            );
        };
    }
}