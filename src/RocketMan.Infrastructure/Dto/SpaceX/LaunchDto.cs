using Newtonsoft.Json;

namespace RocketMan.Infrastructure.Dto.SpaceX
{
    public class LaunchDto
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("mission_name")]
        public string MissionName { get; set; }

        [JsonProperty("launch_date_unix")]
        public int LaunchDateUnix { get; set; }

        [JsonProperty("launch_site")]
        public LaunchSite LaunchSite { get; set; }
    }

    public class LaunchSite
    {
        [JsonProperty("site_name")]
        public string SiteName { get; set; }
    }
}