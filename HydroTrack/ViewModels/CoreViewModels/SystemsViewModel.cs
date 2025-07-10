using CommunityToolkit.Mvvm.ComponentModel;
using HydroTrack.Services;
using HydroTrack.ViewModels.Base;

namespace HydroTrack.ViewModels.CoreViewModels
{
    public partial class SystemsViewModel : NavigableViewModel
    {
        public SystemsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

    }
}
