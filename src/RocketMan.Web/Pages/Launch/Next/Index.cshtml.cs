using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RocketMan.Web.Interfaces;
using RocketMan.Web.ViewModels;

namespace RocketMan.Web.Pages.Launch.Next
{
    public class IndexModel : PageModel
    {
        private readonly ILaunchPageService _launchPageService;

        public IndexModel(ILaunchPageService launchPageService)
        {
            _launchPageService = launchPageService ?? throw new ArgumentNullException(nameof(launchPageService));
        }

        public LaunchViewModel NextLaunch { get; set; }
        public string testText { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            NextLaunch = await _launchPageService.GetNextLaunch();
            return Page();
        }
    }
}