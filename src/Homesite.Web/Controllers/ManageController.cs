using Homesite.Application.Common.Interfaces.Services.Parameters.Process;
using Homesite.Application.Common.Interfaces.Services.Process;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;
using Homesite.Application.Common.Interfaces.Services.Web;
using Homesite.Infrastructure.Services.Parameters.Process;
using Homesite.Infrastructure.Services.Web;
using Homesite.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homesite.Web.Controllers
{
    public class ManageController : Controller
    {

        private readonly IProjectParserService _projectParserService;
        private readonly IProjectImportService _projectImportService;

        public ManageController(
            IProjectParserService projectParserService,
            IProjectImportService projectImportService
        )
        {
            _projectParserService = projectParserService;
            _projectImportService = projectImportService;
           
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
        public async Task<IActionResult> Projects([FromForm] ProjectUploadViewModel model, CancellationToken cancellationToken)
        {
            if (model.HasFileUpload)
            {
                MemoryStream ms = new MemoryStream();

                model.ProjectUpload.CopyTo(ms);

                if (ms != null)
                {
                    
                    IProjectParserResult parserResult =  _projectParserService.ParseProjects(ms);

                    if (!parserResult.Success)
                    {
                        model.Errors.Add("Upload Error");
                        model.Errors.Add(parserResult.Error.Message);
                    }
                    else
                    {
                        IProjectImportParameters importParameters = new ProjectImportParameters();

                        importParameters.ParsedRecords = parserResult.ParsedProjects;

                        IProjectImportResult importResult =
                            await _projectImportService.ImportProjects(importParameters, cancellationToken);

                        if (!importResult.Success)
                        {
                            model.Errors.Add("Import Error");
                            model.Errors.Add(importResult.Error.Message);
                        }
                        else
                        {
                            
                        }

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
