using HydroTrack.ViewModels;

namespace HydroTrack.Views;

public partial class MainView : ContentPage
{
	public MainView(MainViewModel mainVM)
	{
		InitializeComponent();
		BindingContext = mainVM;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        AnimatePulse(LeftPulseLine);
        AnimatePulse(RightPulseLine);
    }

    private void AnimatePulse(VisualElement element)
    {
        _ = Task.Run(async () =>
        {
            while (true)
            {
                await element.FadeTo(0.8, 1000, Easing.SinInOut);
                await element.FadeTo(0.2, 1000, Easing.SinInOut);
            }
        });
    }
}