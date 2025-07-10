using HydroTrack.Services;
using HydroTrack.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroTrack.ViewModels.SettingsViewModels
{
    public partial class ConnectionSetingsViewModel : NavigableViewModel
    {
        public ConnectionSetingsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }
    }
}
