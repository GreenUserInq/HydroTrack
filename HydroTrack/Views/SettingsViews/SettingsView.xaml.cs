using HydroTrack.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace HydroTrack.Views.SettingsViews;

public partial class SettingsView : ContentView
{
    private readonly Color normalColor = Color.FromArgb("#BDEF0F");
    private readonly Color pressedColor = Color.FromArgb("#A0D500");

    public SettingsView(SettingsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
