using System.Web.Mvc;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.UI.Controllers
{
    public class HomeController : BaseController
    {

        // GET: Home
        public ActionResult Index(CarItemViewModel model)
        {
            return View(model);
        }
    }
}