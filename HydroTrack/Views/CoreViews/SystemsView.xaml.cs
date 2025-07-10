using HydroTrack.ViewModels.CoreViewModels;

namespace HydroTrack.Views.CoreViews;

public partial class SystemsView : ContentView
{
	public SystemsView(SystemsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}