using System.Collections.Generic;
using System.Threading.Tasks;
using RocketMan.Core.Entities;
using RocketMan.Core.Repositories.Base;

namespace RocketMan.Core.Repositories
{
    public interface ILaunchRepository : IRepository<Launch>
    {
        Task<IEnumerable<Launch>> GetFavoriteList();
        Task<Launch> AddToFavorite(Launch launch);
        Task RemoveFromFavorite(Launch launch);
    }
}
