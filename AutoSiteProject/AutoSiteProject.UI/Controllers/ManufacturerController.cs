using System.Web.Mvc;
using AutoSiteProject.Models.ViewModels;
using AutoSiteProject.Models.DB;
using System.Linq;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using System;
using AutoSiteProject.Models.Bl.Interfaces.Managers;

namespace AutoSiteProject.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManufacturerController : BaseController
    {
        private readonly IManufacturerManager _manufacturerManager;
        private readonly IManufacturerFieldCopier _manufacturerFieldCopier;
        private readonly ICountryManager _countryManager;

        public ManufacturerController(
            IManufacturerManager manufacturerManager,
            ICountryManager countryManager,
            IManufacturerFieldCopier manufacturerFieldCopier)
        {
            _manufacturerManager = manufacturerManager;
            _countryManager = countryManager;
            _manufacturerFieldCopier = manufacturerFieldCopier;
        }

        // GET: Country
        public ActionResult List()
        {
            return View();
        }

        //GET 
        public ActionResult Create()
        {
            ViewBag.Countries = new SelectList(_countryManager.GetAll().ToList(), "Id", "Name");
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Create(ManufacturerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _manufacturerManager.Add(_manufacturerFieldCopier.CopyFields(model, new Manufacturer()));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            ViewBag.Countries = new SelectList(_countryManager.GetAll().ToList(), "Id", "Name");
            var dbItem = _manufacturerManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            return View(_manufacturerFieldCopier.CopyFields(dbItem, new ManufacturerViewModel()));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(ManufacturerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbItem = _manufacturerManager.GetById(model.Id);
                if (dbItem == null) throw new NullReferenceException();
                dbItem = _manufacturerFieldCopier.CopyFields(model, dbItem);
                _manufacturerManager.Edit(dbItem);
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            var dbItem = _manufacturerManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            _manufacturerManager.Delete(dbItem);
            return RedirectToAction("List");
        }
    }
}