using System;
using RocketMan.Core.Entities.Base;

namespace RocketMan.Core.Entities
{
    public class Launch : Entity
    {
        public string MissionName { get; set; }
        public DateTimeOffset LaunchDate { get; set; }
        public string Launchpad { get; set; }

        public static Launch Create(string id, string name, DateTimeOffset launchDate, string launchpad)
        {
            return new()
            {
                Id = id,
                MissionName = name,
                LaunchDate = launchDate,
                Launchpad = launchpad
            };
        }
    }
}