using System.Text.Json.Serialization;

namespace RocketMan.Infrastructure.Dto.SpaceX
{
    public class LaunchDto
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("mission_name")]
        public string MissionName { get; set; }

        [JsonPropertyName("launch_date_unix")]
        public int LaunchDateUnix { get; set; }

        [JsonPropertyName("launch_site")]
        public LaunchSite LaunchSite { get; set; }
        
    }
    public class LaunchSite
    {
        [JsonPropertyName("site_name")]
        public string SiteName { get; set; }
    }
}