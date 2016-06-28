using System.Collections.Generic;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.ViewModels;
using AutoSiteProject.Models.DB;
using System.Linq;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;

namespace AutoSiteProject.UI.Controllers
{
    public class ManufacturerController : BaseController
    {
        private IManufacturerManager _manufacturerManager;
        private IManufacturerFieldCopier _manufacturerFieldCopier;
        private ICountryManager _countryManager;

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
            var dbItems = _manufacturerManager.GetAll().ToList();
            var result = new List<ManufacturerViewModel>();
            foreach (var item in dbItems)
            {
                result.Add(_manufacturerFieldCopier.CopyFields(item, new ManufacturerViewModel()));
            }
            return View(result);
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
            return View(_manufacturerFieldCopier.CopyFields(dbItem, new ManufacturerViewModel()));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(ManufacturerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbItem = _manufacturerManager.GetById(model.Id);
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
            _manufacturerManager.Delete(dbItem);
            return RedirectToAction("List");
        }
    }
}