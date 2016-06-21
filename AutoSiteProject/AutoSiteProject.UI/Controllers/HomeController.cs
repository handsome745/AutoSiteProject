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
        public ActionResult Index(int countryId = -1)
        {
            var countries = Mapper.Map<List<CountryViewModel>>(_countryManager.GetAll().ToList());
            ViewBag.Countries = new SelectList(countries, "Id", "Name", countryId);
            ViewBag.Manufacturers = new SelectList(new List<ManufacturerViewModel>(), "Id", "Name");
            ViewBag.CarModels = new SelectList(new List<CarModelViewModel>(), "Id", "Name");
            ViewBag.CarBodyTypes = new SelectList(new List<CarBodyTypeViewModel>(), "Id", "Name");
            return View();
        }

       
    }
}