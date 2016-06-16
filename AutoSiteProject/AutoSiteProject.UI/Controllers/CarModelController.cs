using AutoSiteProject.Models.Bl.Interfaces;
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
        private IRepositoryManager<CarModelViewModel> _carModelManager;
        private IRepositoryManager<ManufacturerViewModel> _manufacturerManager;

        public CarModelController(IRepositoryManager<CarModelViewModel> carModelManager,
            IRepositoryManager<ManufacturerViewModel> manufacturerManager)
        {
            _manufacturerManager = manufacturerManager;
            _carModelManager = carModelManager;
        }


        // GET: CarModel
        public ActionResult List()
        {
            return View(_carModelManager.GetAll());
        }


        //GET 
        public ActionResult Create()
        {
            ViewBag.Manufacturers = new SelectList(_manufacturerManager.GetAll(),"Id", "Name");
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Create(CarModelViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _carModelManager.Add(entity);
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            ViewBag.Manufacturers = new SelectList(_manufacturerManager.GetAll(), "Id", "Name");
            return View(_carModelManager.GetById(id));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CarModelViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _carModelManager.Edit(entity);
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            var entityForDelete = _carModelManager.GetById(id);
            if (entityForDelete != null) _carModelManager.Delete(entityForDelete);
            return RedirectToAction("List");
        }
    }
}