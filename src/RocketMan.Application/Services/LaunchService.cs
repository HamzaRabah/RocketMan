using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RocketMan.Application.Interfaces;
using RocketMan.Application.Mapper;
using RocketMan.Application.Models;
using RocketMan.Application.Services.Base;
using RocketMan.Core.Entities;
using RocketMan.Core.Interfaces;
using RocketMan.Core.Repositories;

namespace RocketMan.Application.Services
{
    public class LaunchService : BaseService, ILaunchService
    {
        private readonly ILaunchRepository _launchRepository;
        private readonly ISpaceApiService _spaceApiService;
        private readonly IApplicationLogger<LaunchService> _logger;

        public LaunchService(ILaunchRepository launchRepository, ISpaceApiService spaceApiService,
            IApplicationLogger<LaunchService> logger)
        {
            _launchRepository = launchRepository ?? throw new ArgumentNullException(nameof(launchRepository));
            _spaceApiService = spaceApiService ?? throw new ArgumentNullException(nameof(spaceApiService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<LaunchModel>> GetUpcomingLaunches()
        {
            var upcomingLaunches = await _spaceApiService.GetUpcomingLaunches();
            var result = ObjectMapper.Mapper.Map<IEnumerable<LaunchModel>>(upcomingLaunches);
            var favoriteList = (await _launchRepository.GetFavoriteList())?.ToList();
            foreach (var item in result.Where(model => favoriteList.Exists(launch => launch.Id == model.Id)))
                item.IsFavorite = true;
            return result;
        }

        public async Task<IEnumerable<LaunchModel>> GetFavoriteLaunches()
        {
            var favoriteList = await _launchRepository.GetFavoriteList();
            return ObjectMapper.Mapper.Map<IEnumerable<LaunchModel>>(favoriteList);
        }

        public async Task<LaunchModel> GetNextLaunch()
        {
            var upcomingLaunches = await _spaceApiService.GetNextLaunch();
            return ObjectMapper.Mapper.Map<LaunchModel>(upcomingLaunches);
        }

        public async Task<LaunchModel> AddToFavorite(LaunchModel launch)
        {
            var launchToAdd = ObjectMapper.Mapper.Map<Launch>(launch);
            launchToAdd = await _launchRepository.AddToFavorite(launchToAdd);
            return ObjectMapper.Mapper.Map<LaunchModel>(launchToAdd);
        }

        public async Task RemoveFromFavorite(LaunchModel launch)
        {
            var launchToRemove = ObjectMapper.Mapper.Map<Launch>(launch);
            await _launchRepository.RemoveFromFavorite(launchToRemove);
        }
    }
}