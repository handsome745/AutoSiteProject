using AutoSiteProject.Models.Bl.Interfaces;
using System.Web.Mvc;

namespace AutoSiteProject.UI.Controllers
{
    public abstract class BaseController : Controller
    {
        public IAppLogger AppLogger { get; set; }

    }
}