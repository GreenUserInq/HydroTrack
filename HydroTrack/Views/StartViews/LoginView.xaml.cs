using HydroTrack.ViewModels;

namespace HydroTrack.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}