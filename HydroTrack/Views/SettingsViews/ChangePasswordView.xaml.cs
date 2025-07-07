using HydroTrack.ViewModels;

namespace HydroTrack.Views.SettingsViews;

public partial class ChangePasswordView : ContentView
{
	public ChangePasswordView(ChangePasswordViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}