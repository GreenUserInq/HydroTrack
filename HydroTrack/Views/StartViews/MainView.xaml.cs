using HydroTrack.ViewModels;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using static Microsoft.Maui.Controls.AnimationExtensions;

namespace HydroTrack.Views;

public partial class MainView : ContentPage
{
    private bool _menuVisible = false;
    private const uint AnimationDuration = 200;
    private bool _menuFlag;

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
        _menuFlag = true;
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

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (BindingContext is MainViewModel vm)
        {
            vm.PropertyChanged -= ViewModel_PropertyChanged;
            vm.PropertyChanged += ViewModel_PropertyChanged;
        }
    }

    private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MainViewModel.CurrentView))
        {
            if (BindingContext is MainViewModel vm && !IsChangeFromMenu(vm))
            {
                ResetRadioButtons();
            }
        }
    }

    private bool IsChangeFromMenu(MainViewModel vm)
    {
        // Читаем и сбрасываем флаг
        var result = vm.GetType().GetField("_changedFromMenu", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(vm) as bool? ?? false;
        vm.GetType().GetField("_changedFromMenu", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(vm, false);
        return result;
    }

    private void ResetRadioButtons()
    {
        if (!_menuFlag)
        {
            HomeRadioButton.IsChecked = false;
            SettingsRadioButton.IsChecked = false;
            PassRadioButton.IsChecked = false;
        }
        _menuFlag = false;
    }
}
