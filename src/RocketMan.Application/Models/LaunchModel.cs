using System;
using RocketMan.Application.Models.Base;

namespace RocketMan.Application.Models
{
    public class LaunchModel : BaseModel
    {
        public string MissionName { get; set; }
        public DateTimeOffset LaunchDate { get; set; }
        public string Launchpad { get; set; }
        public bool IsFavorite { get; set; }
    }
}