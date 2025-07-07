using Microsoft.Maui.Controls;
using static Microsoft.Maui.Controls.AnimationExtensions;
using HydroTrack.ViewModels;

namespace HydroTrack.Views;

public partial class MainView : ContentPage
{
    private bool _menuVisible = false;
    private const uint AnimationDuration = 200;

    public MainView(MainViewModel mainVM)
    {
        InitializeComponent();
        BindingContext = mainVM;
    }

    private async void OnMenuButtonClicked(object sender, EventArgs e)
    {
        if (_menuVisible)
        {
            await Sidebar.TranslateTo(-Sidebar.Width, 0, AnimationDuration, Easing.CubicOut);
            Sidebar.IsVisible = false;
        }
        else
        {
            Sidebar.IsVisible = true;
            Sidebar.TranslationX = -Sidebar.Width;
            await Sidebar.TranslateTo(0, 0, AnimationDuration, Easing.CubicOut);
        }

        _menuVisible = !_menuVisible;
    }

    private async void OnMenuItemSelected(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value && sender is RadioButton radio &&
            BindingContext is MainViewModel vm &&
            radio.Value is string selected)
        {
            if (vm.MenuSelectCommand.CanExecute(selected))
                vm.MenuSelectCommand.Execute(selected);

            await Sidebar.TranslateTo(-Sidebar.Width, 0, AnimationDuration, Easing.CubicOut);
            Sidebar.IsVisible = false;
            _menuVisible = false;
        }
    }
}
