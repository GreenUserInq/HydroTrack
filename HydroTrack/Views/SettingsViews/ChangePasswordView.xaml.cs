using HydroTrack.ViewModels;
namespace HydroTrack.Views.SettingsViews;

public partial class ChangePasswordView : ContentPage
{
	public ChangePasswordView(ChangePasswordViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}