using HydroTrack.ViewModels.HomeViewModels;

namespace HydroTrack.Views.HomeViews;

public partial class HomeView : ContentView
{
	public HomeView(HomeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}