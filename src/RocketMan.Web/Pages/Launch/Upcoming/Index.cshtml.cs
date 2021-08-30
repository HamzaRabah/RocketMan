using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RocketMan.Web.Interfaces;
using RocketMan.Web.ViewModels;

namespace RocketMan.Web.Pages.Launch.Upcoming
{
    public class IndexModel : PageModel
    {
        private readonly ILaunchPageService _launchPageService;

        public IndexModel(ILaunchPageService launchPageService)
        {
            _launchPageService = launchPageService ?? throw new ArgumentNullException(nameof(launchPageService));
        }

        public IEnumerable<LaunchViewModel> UpcomingList { get; set; } = new List<LaunchViewModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            UpcomingList = await _launchPageService.GetUpcomingLaunches();
            return Page();
        }
    }
}