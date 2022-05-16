using Homesite.Application.Common.Interfaces.Services.Parameters.Process;
using Homesite.Application.Common.Interfaces.Services.Persistence;
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
        private readonly IProjectDataService _projectDataService;

        public ManageController(
            IProjectParserService projectParserService,
            IProjectImportService projectImportService,
            IProjectDataService projectDataService
        )
        {
            _projectParserService = projectParserService;
            _projectImportService = projectImportService;
            _projectDataService = projectDataService;

        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Projects(CancellationToken cancellationToken)
        {
            ProjectUploadViewModel model = new ProjectUploadViewModel();

            model.PopulateExistingProjects(_projectDataService.All(cancellationToken).Result.Records);

            return View(model);
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

                            if (importResult.Error != null)
                            {
                                model.Errors.Add(importResult.Error.Message);
                            }
                        }
                        else
                        {
                            model.PopulateExistingProjects(_projectDataService.All(cancellationToken).Result.Records);
                        }

                    }

                }
            }

            return View(model);
        }

        [HttpPost][Authorize]
        public async Task<IActionResult> DeleteProjects([FromBody] List<int> ids, CancellationToken cancellationToken)
        {
            if (ids.Count > 0)
            {
                await _projectDataService.DeleteProjects(ids, cancellationToken);
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }

            
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
