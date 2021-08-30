using System.Collections.Generic;
using System.Threading.Tasks;
using RocketMan.Core.Entities;

namespace RocketMan.Core.Interfaces
{
    public interface ISpaceApiService
    {
        Task<IEnumerable<Launch>> GetUpcomingLaunches();
        Task<Launch> GetNextLaunch();
    }
}
