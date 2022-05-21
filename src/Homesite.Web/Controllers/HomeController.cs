using Homesite.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Homesite.Application.Common.Interfaces.Services.Persistence;
using Homesite.Application.Common.Interfaces.Services.Persistence.Responses;

namespace Homesite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectDataService _projectDataService;

        public HomeController(ILogger<HomeController> logger, IProjectDataService projectDataService)
        {
            _logger = logger;
            _projectDataService= projectDataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Skills()
        {
            return View();
        }

        public IActionResult Clients()
        {
            return View();
        }

        public async Task<IActionResult> Projects(CancellationToken token)
        {
            ProjectDisplayViewModel model = new ProjectDisplayViewModel();
            IProjectDataResult dataResult = await _projectDataService.All(token);

            if (dataResult.Records.Count > 0)
            {
                model.Projects = dataResult.Records;
            }
            

            return View(model);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}