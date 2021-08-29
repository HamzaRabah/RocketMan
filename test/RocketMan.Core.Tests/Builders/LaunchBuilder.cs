using System;

namespace RocketMan.Core.Tests.Builders
{
    public static class LaunchBuilder
    {
        public static string LaunchId1 => "123";
        public static string LaunchMissionName1 => "test mission";
        public static DateTimeOffset LaunchLaunchDate1 => DateTimeOffset.FromUnixTimeSeconds(1630253516);
        public static string Launchpad1 => "test launch pad";
    }
}
