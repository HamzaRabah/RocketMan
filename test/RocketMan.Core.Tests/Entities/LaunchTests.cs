using RocketMan.Core.Entities;
using RocketMan.Core.Tests.Builders;
using Xunit;

namespace RocketMan.Core.Tests.Entities
{
    public class LaunchTests
    {
        [Fact]
        public void Create_Launch()
        {
            var launch = Launch.Create(LaunchBuilder.LaunchId1,
                LaunchBuilder.LaunchMissionName1,
                LaunchBuilder.LaunchLaunchDate1,
                LaunchBuilder.Launchpad1);

            Assert.Equal(LaunchBuilder.LaunchId1, launch.Id);
            Assert.Equal(LaunchBuilder.LaunchMissionName1, launch.MissionName);
            Assert.Equal(LaunchBuilder.LaunchLaunchDate1, launch.LaunchDate);
            Assert.Equal(LaunchBuilder.Launchpad1, launch.Launchpad);
        }
    }
}