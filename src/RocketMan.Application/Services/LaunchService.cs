using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RocketMan.Application.Interfaces;
using RocketMan.Application.Mapper;
using RocketMan.Application.Models;
using RocketMan.Application.Services.Base;
using RocketMan.Core.Interfaces;

namespace RocketMan.Application.Services
{
    public class LaunchService : BaseService, ILaunchService
    {
        private readonly ISpaceApiService _spaceApiService;
        private readonly IApplicationLogger<LaunchService> _logger;

        public LaunchService(ISpaceApiService spaceApiService, IApplicationLogger<LaunchService> logger)
        {
            _spaceApiService = spaceApiService ?? throw new ArgumentNullException(nameof(spaceApiService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<LaunchModel>> GetUpcomingLaunches()
        {
            var upcomingLaunches = await _spaceApiService.GetUpcomingLaunches();
            return ObjectMapper.Mapper.Map<IEnumerable<LaunchModel>>(upcomingLaunches);
        }

        public async Task<LaunchModel> GetNextLaunch()
        {
            var upcomingLaunches = await _spaceApiService.GetNextLaunch();
            return ObjectMapper.Mapper.Map<LaunchModel>(upcomingLaunches);
        }
    }
}