using System.Collections.Generic;
using System.Threading.Tasks;
using RocketMan.Application.Models;

namespace RocketMan.Application.Interfaces
{
    public interface ILaunchService
    {
        Task<IEnumerable<LaunchModel>> GetUpcomingLaunches();
        Task<IEnumerable<LaunchModel>> GetFavoriteLaunches();
        Task<LaunchModel> GetNextLaunch();
        Task<LaunchModel> AddToFavorite(LaunchModel launch);
        Task RemoveFromFavorite(LaunchModel launch);
    }
}