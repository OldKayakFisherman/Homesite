using Homesite.Application.Common.Interfaces.Services.Process;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;
using Homesite.Application.Common.Interfaces.Services.Web;
using Homesite.Infrastructure.Services.Web;
using Homesite.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homesite.Web.Controllers
{
    public class ManageController : Controller
    {

        private readonly IProjectParserService _projectParserService;
        private readonly IUploadUtilityService _uploadUtilityService;

        public ManageController(
            IProjectParserService projectParserService,
            IUploadUtilityService uploadUtilityService
        )
        {
            _projectParserService = projectParserService;
            _uploadUtilityService = uploadUtilityService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Projects()
        {
            return View(new ProjectUploadViewModel());
        }

        [HttpPost, Authorize]
        public IActionResult Projects([FromForm] ProjectUploadViewModel model)
        {
            if (model.HasFileUpload)
            {
                MemoryStream? ms = _uploadUtilityService.ConvertPostedFileToMemoryStream(model.ProjectUpload);

                if (ms != null)
                {
                    IProjectParserResult parserResult =  _projectParserService.ParseProjects(ms);

                    if (!parserResult.Success)
                    {
                        model.Errors = parserResult.Messages;
                    }

                }
            }

            return View(model);
        }


        [Authorize]
        public IActionResult Traffic()
        {
            return View();
        }

        [Authorize]
        public IActionResult SiteErrors()
        {
            return View();
        }

        [Authorize]
        public IActionResult Banned()
        {
            return View();
        }

        [Authorize]
        public IActionResult Logout()
        {
            return RedirectToAction("Logout", "Account", "Identity");
        }


    }
}
