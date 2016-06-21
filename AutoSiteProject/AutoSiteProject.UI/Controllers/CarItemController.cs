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
        public ActionResult Create()
        {
            ViewBag.Countries = new SelectList(_countryManager.GetAll().ToList(), "Id", "Name");
            ViewBag.Manufacturers = new SelectList(new List<ManufacturerViewModel>(), "Id", "Name");
            ViewBag.CarModels = new SelectList(new List<CarModelViewModel>(), "Id", "Name");
            ViewBag.CarOptions = _carOptionManager.GetAll().ToList();
            ViewBag.CarBodyTypes = _carBodyTypeManager.GetAll().ToList();
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Create(CarItemViewModel model)
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
            return View(Mapper.Map<CarItemViewModel>(_carItemManager.GetById(id)));
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