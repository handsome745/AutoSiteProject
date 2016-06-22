using AutoMapper;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSiteProject.UI.Controllers
{
    public class CarItemController : Controller
    {
        private ICountryManager _countryManager;
        private IManufacturerManager _manufacturerManager;
        private ICarModelManager _carModelManager;
        private ICarItemManager _carItemManager;
        private ICarOptionManager _carOptionManager;
        private ICarBodyTypeManager _carBodyTypeManager;

        public CarItemController(
            ICountryManager countryManager,
            IManufacturerManager manufacturerManager,
            ICarModelManager carModelManager,
            ICarItemManager carItemManager,
            ICarOptionManager carOptionManager,
            ICarBodyTypeManager carBodyTypeManager
            )
        {
            _countryManager = countryManager;
            _manufacturerManager = manufacturerManager;
            _carModelManager = carModelManager;
            _carItemManager = carItemManager;
            _carOptionManager = carOptionManager;
            _carBodyTypeManager = carBodyTypeManager;
        }
        // GET
        public ActionResult List()
        {
            var result = Mapper.Map<List<CarItemViewModel>>(_carItemManager.GetAll().ToList());
            return View(result);
        }

        //GET 
        public ActionResult Create(CarItemViewModel model)
        {
            return View(model);
        }
        //Post
        [HttpPost]
        public ActionResult CreateCar(CarItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                _carItemManager.Add(Mapper.Map<CarItem>(model));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            var result = Mapper.Map<CarItemViewModel>(_carItemManager.GetById(id)) ;
            result.ManufacturerId = result.CarModel.ManufacturerId;
            result.Manufacturer = result.CarModel.Manufacturer;
            result.CountryId = result.Manufacturer.CountryId;
            result.Country = result.Manufacturer.Country;
            return View(result);
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CarItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                _carItemManager.Edit(Mapper.Map<CarItem>(model));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            _carOptionManager.Delete(id);
            return RedirectToAction("List");
        }
    }
}