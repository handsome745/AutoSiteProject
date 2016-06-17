using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private ICarModelManager _carModelManager;
        private IManufacturerManager _manufacturerManager;
        private ICountryManager _countryManager;

        public HomeController(ICarModelManager carModelManager,
            IManufacturerManager manufacturerManager,
            ICountryManager countryManager)
        {
            _carModelManager = carModelManager;
            _manufacturerManager = manufacturerManager;
            _countryManager = countryManager;
        }

        // GET: Home
        public ActionResult Index(int countryId = -1)
        {
            ViewBag.Countries = new SelectList(_countryManager.GetAll(), "Id", "Name");
            ViewBag.Manufacturers = new SelectList(new List<ManufacturerViewModel>(), "Id", "Name");
            ViewBag.CarModels = new SelectList(_carModelManager.GetAll(), "Id", "Name");
            return View();
        }

        public JsonResult GetManufacturersOfCountry(int id)
        {
            var result = _manufacturerManager.GetAll().Where(m => m.CountryId == id);
            return Json(result);
        }
    }
}