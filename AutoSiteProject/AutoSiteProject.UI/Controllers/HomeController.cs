using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.ViewModels;
using AutoMapper;

namespace AutoSiteProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private ICountryManager _countryManager;

        public HomeController(ICountryManager countryManager)
        {
            _countryManager = countryManager;
        }

        // GET: Home
        public ActionResult Index(CarItemViewModel model)
        {
            return View(model);
        }
    }
}