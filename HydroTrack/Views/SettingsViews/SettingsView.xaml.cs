using HydroTrack.ViewModels;

namespace HydroTrack.Views;

public partial class SettingsView : ContentPage
{
	public SettingsView(SettingsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private bool isMenuOpen = false;

    private async void OnMenuClicked(object sender, EventArgs e)
    {
        const int animationSteps = 10;
        const int totalDurationMs = 150; // 150 мс Ч быстро, но не мгновенно
        double delay = totalDurationMs / (double)animationSteps;

        double start = isMenuOpen ? 8 : 0;
        double end = isMenuOpen ? 0 : 8;

        for (int i = 1; i <= animationSteps; i++)
        {
            double t = i / (double)animationSteps;
            double current = Lerp(start, end, t);

            MainGrid.ColumnDefinitions[0].Width = new GridLength(current, GridUnitType.Star);
            MainGrid.ColumnDefinitions[1].Width = new GridLength(100 - current, GridUnitType.Star);

            await Task.Delay((int)delay);
        }

        isMenuOpen = !isMenuOpen;
    }

    private double Lerp(double a, double b, double t) => a + (b - a) * t;
}