using System.Collections.Generic;
using System.Threading.Tasks;
using RocketMan.Application.Models;

namespace RocketMan.Application.Interfaces
{
    public interface ILaunchService
    {
        Task<IEnumerable<LaunchModel>> GetUpcomingLaunches();
        Task<LaunchModel> GetNextLaunch();
    }
}