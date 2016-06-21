using System.Collections.Generic;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.ViewModels;
using AutoMapper;
using AutoSiteProject.Models.DB;
using System.Linq;

namespace AutoSiteProject.UI.Controllers
{
    public class ManufacturerController : Controller
    {
        private IManufacturerManager _manufacturerManager;
        private ICountryManager _countryManager;

        public ManufacturerController(IManufacturerManager manufacturerManager, ICountryManager countryManager)
        {
            _manufacturerManager = manufacturerManager;
            _countryManager = countryManager;
        }

        // GET: Country
        public ActionResult List()
        {
            return View(Mapper.Map<List<ManufacturerViewModel>>( _manufacturerManager.GetAll().ToList() ));
        }

        //GET 
        public ActionResult Create()
        {
            ViewBag.Countries = new SelectList(_countryManager.GetAll().ToList(), "Id", "Name");
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Create(ManufacturerViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _manufacturerManager.Add(Mapper.Map<Manufacturer>(entity));
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            ViewBag.Countries = new SelectList(_countryManager.GetAll().ToList(), "Id", "Name");
            return View(_manufacturerManager.GetById(id));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(ManufacturerViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _manufacturerManager.Edit(Mapper.Map<Manufacturer>(entity));
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            _manufacturerManager.Delete(id);
            return RedirectToAction("List");
        }
    }
}