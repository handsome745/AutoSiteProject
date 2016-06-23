using AutoSiteProject.Models.Bl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace AutoSiteProject.UI.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : Controller
    {
        private ICountryManager _countryManager;

        public ValidationController(ICountryManager countryManager)
        {
            _countryManager = countryManager;
        }

        // GET: Validation
        public JsonResult CheckCountryNameForExist(string Name)
        {
            if (_countryManager.GetAll().Where(c=>c.Name == Name).ToList().Count > 0)
            return Json(true, JsonRequestBehavior.AllowGet);
            else return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}