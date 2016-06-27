
using System.ComponentModel;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.UI.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index(CarItemViewModel model)
        {
            return View(model);
        }
    }
}