using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.UI.Controllers
{
    public class ManufacturerController : Controller
    {
        private IRepositoryManager<ManufacturerViewModel> _manufacturerManager;
        private IRepositoryManager<CountryViewModel> _countryManager;

        public ManufacturerController(IRepositoryManager<ManufacturerViewModel> manufacturerManager, IRepositoryManager<CountryViewModel> countryManager)
        {
            _manufacturerManager = manufacturerManager;
            _countryManager = countryManager;
        }

        // GET: Country
        public ActionResult List()
        {
            ViewBag.Countries =_countryManager.GetAll();
            return View(_manufacturerManager.GetAll());
        }

        //GET 
        public ActionResult Create()
        {
            ViewBag.Countries = new SelectList(_countryManager.GetAll(), "Id", "Name");
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Create(ManufacturerViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _manufacturerManager.Add(entity);
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            ViewBag.Countries = new SelectList(_countryManager.GetAll(), "Id", "Name");
            return View(_manufacturerManager.GetById(id));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(ManufacturerViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _manufacturerManager.Edit(entity);
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            var entityForDelete = _manufacturerManager.GetById(id);
            if (entityForDelete != null) _manufacturerManager.Delete(entityForDelete);
            return RedirectToAction("List");
        }
    }
}