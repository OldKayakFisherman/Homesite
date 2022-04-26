using Homesite.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homesite.Web.Controllers
{
    public class ManageController : Controller
    {
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
