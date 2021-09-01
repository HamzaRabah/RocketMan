using System.Collections.Generic;
using System.Threading.Tasks;
using RocketMan.Core.Entities;
using RocketMan.Core.Repositories;
using RocketMan.Infrastructure.Data;
using RocketMan.Infrastructure.Repositories.Base;

namespace RocketMan.Infrastructure.Repositories
{
    public class LaunchRepository : BaseRepository<Launch>, ILaunchRepository
    {
        public LaunchRepository(RocketManDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Launch>> GetFavoriteList()
        {
            return await GetAllAsync();
        }

        public async Task<Launch> AddToFavorite(Launch launch)
        {
            return await AddAsync(launch);
        }

        public async Task RemoveFromFavorite(Launch launch)
        {
            await DeleteAsync(launch);
        }
    }
}