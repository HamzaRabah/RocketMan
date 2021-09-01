using System;

namespace RocketMan.Web.ViewModels
{
    public class LaunchViewModel : BaseViewModel
    {
        public string MissionName { get; set; }
        public DateTimeOffset LaunchDate { get; set; }
        public string Launchpad { get; set; }
        public bool IsFavorite { get; set; }
    }
}
