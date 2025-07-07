using CommunityToolkit.Mvvm.ComponentModel;
using HydroTrack.Services;

namespace HydroTrack.ViewModels.Base
{
    public abstract partial class NavigableViewModel : ObservableObject
    {
        protected readonly INavigationService NavigationService;

        protected NavigableViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
