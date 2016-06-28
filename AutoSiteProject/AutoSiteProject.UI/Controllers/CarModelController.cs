using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using System;

namespace AutoSiteProject.UI.Controllers
{
    public class CarModelController : BaseController
    {
        private ICarModelManager _carModelManager;
        private IManufacturerManager _manufacturerManager;
        private ICarModelFieldCopier _carModelFieldCopier;

        public CarModelController(ICarModelManager carModelManager,
            IManufacturerManager manufacturerManager,
            ICarModelFieldCopier carModelFieldCopier)
        {
            _manufacturerManager = manufacturerManager;
            _carModelManager = carModelManager;
            _carModelFieldCopier = carModelFieldCopier;
        }

        // GET: CarModel
        public ActionResult List()
        {
            var dbItems = _carModelManager.GetAll().ToList();
            var result = new List<CarModelViewModel>();
            foreach (var item in dbItems)
            {
                result.Add(_carModelFieldCopier.CopyFields(item, new CarModelViewModel()));
            }
            return View(result);
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
                _carModelManager.Add(_carModelFieldCopier.CopyFields(model, new CarModel()));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            var dbItem = _carModelManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            ViewBag.Manufacturers = new SelectList(_manufacturerManager.GetAll().ToList(), "Id", "Name");
            return View(_carModelFieldCopier.CopyFields(dbItem, new CarModelViewModel()));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CarModelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbItem = _carModelManager.GetById(model.Id);
                if (dbItem == null) throw new NullReferenceException();
                dbItem = _carModelFieldCopier.CopyFields(model, dbItem);
                _carModelManager.Edit(dbItem);
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            var dbItem = _carModelManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            _carModelManager.Delete(dbItem);
            return RedirectToAction("List");
        }
    }
}