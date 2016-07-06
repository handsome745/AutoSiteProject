using System.Web.Mvc;

namespace AutoSiteProject.UI.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InternalServer()
        {
            Response.StatusCode = 200;
            return View();
        }
        public ActionResult NotFound()
        {
            Response.StatusCode = 200;
            return View();
        }
        public ActionResult BadRequest()
        {
            Response.StatusCode = 200;
            return View();
        }
    }
}