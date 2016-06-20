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
            var countries = new List<CountryViewModel>();
            countries.Add(new CountryViewModel { Id = -1, Name = "Select country..." });
            countries.AddRange(Mapper.Map<List<CountryViewModel>>(_countryManager.GetAll()));
            ViewBag.Countries = new SelectList(countries, "Id", "Name", countryId);

            ViewBag.Manufacturers = new SelectList(new List<ManufacturerViewModel>(), "Id", "Name");
            ViewBag.CarModels = new SelectList(new List<CarModelViewModel>(), "Id", "Name");

            return View();
        }

        public JsonResult GetManufacturersOfCountry(int id)
        {
            var result = new List<ManufacturerViewModel>();
            result.Add(new ManufacturerViewModel { Id = -1, Name = "Select manufacturer..." });
            result.AddRange(Mapper.Map<List<ManufacturerViewModel>>(_manufacturerManager.GetAll().Where(m => m.CountryId == id)));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCarModelsOfManufacturer(int id)
        {
            var result = new List<CarModelViewModel>();
            result.Add(new CarModelViewModel { Id = -1, Name = "Select car model..." });
            result.AddRange(Mapper.Map<List<CarModelViewModel>>(_carModelManager.GetAll().Where(m => m.ManufacturerId == id)));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}