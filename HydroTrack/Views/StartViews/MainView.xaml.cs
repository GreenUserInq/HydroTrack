using HydroTrack.ViewModels;
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

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var startColor = Color.FromArgb("#7bc7e3"); // текущий фон
        var endColor = Color.FromArgb("#EAF6F6");   // светло-зелёный / морской волны

        await AnimateBackgroundColor(startColor, endColor);
    }


    private Task AnimateBackgroundColor(Color from, Color to, uint duration = 800)
    {
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

        new Animation(v =>
        {
            BackgroundColor = new Color(
                (float)(from.Red + (to.Red - from.Red) * v),
                (float)(from.Green + (to.Green - from.Green) * v),
                (float)(from.Blue + (to.Blue - from.Blue) * v),
                (float)(from.Alpha + (to.Alpha - from.Alpha) * v));
        }, 0, 1)
        .Commit(this, "ColorAnimation", length: duration, easing: Easing.CubicInOut,
            finished: (v, c) => tcs.SetResult(true));

        return tcs.Task;
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
