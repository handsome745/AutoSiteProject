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
    public class CarModelController : Controller
    {
        private ICarModelManager _carModelManager;
        private IManufacturerManager _manufacturerManager;

        public CarModelController(ICarModelManager carModelManager,
            IManufacturerManager manufacturerManager)
        {
            _manufacturerManager = manufacturerManager;
            _carModelManager = carModelManager;
        }


        // GET: CarModel
        public ActionResult List()
        {
            return View(Mapper.Map<List<CarModelViewModel>>(_carModelManager.GetAll().ToList()));
        }


        //GET 
        public ActionResult Create()
        {
            ViewBag.Manufacturers = new SelectList(_manufacturerManager.GetAll().ToList(), "Id", "Name");
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Create(CarModelViewModel model)
        {
            if (ModelState.IsValid)
            {
                _carModelManager.Add(Mapper.Map<CarModel> (model));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            ViewBag.Manufacturers = new SelectList(_manufacturerManager.GetAll().ToList(), "Id", "Name");
            return View(Mapper.Map<CarModelViewModel>(_carModelManager.GetById(id)));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CarModelViewModel model)
        {
            if (ModelState.IsValid)
            {
                _carModelManager.Edit(Mapper.Map<CarModel>(model));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            _carModelManager.Delete(id);
            return RedirectToAction("List");
        }
    }
}