﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using RocketMan.Application.Interfaces;
using RocketMan.Web.Interfaces;
using RocketMan.Web.ViewModels;

namespace RocketMan.Web.Services
{
    public class LaunchPageService : ILaunchPageService
    {
        private readonly ILaunchService _launchAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<LaunchPageService> _logger;

        public LaunchPageService(ILaunchService launchAppService, IMapper mapper, ILogger<LaunchPageService> logger)
        {
            _launchAppService = launchAppService ?? throw new ArgumentNullException(nameof(launchAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<LaunchViewModel>> GetUpcomingLaunches()
        {
            var list = await _launchAppService.GetUpcomingLaunches();
            return _mapper.Map<IEnumerable<LaunchViewModel>>(list);
        }

        public async Task<LaunchViewModel> GetNextLaunch()
        {
            var next = await _launchAppService.GetNextLaunch();
            return _mapper.Map<LaunchViewModel>(next);
        }
    }
}