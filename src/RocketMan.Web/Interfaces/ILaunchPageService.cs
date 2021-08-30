using System.Collections.Generic;
using System.Threading.Tasks;
using RocketMan.Web.ViewModels;

namespace RocketMan.Web.Interfaces
{
    public interface ILaunchPageService
    {
        Task<IEnumerable<LaunchViewModel>> GetUpcomingLaunches();
        Task<LaunchViewModel> GetNextLaunch();
    }
}