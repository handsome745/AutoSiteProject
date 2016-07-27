using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.Models.ViewModels;
using System;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FuelTypeController : Controller
    {
        private readonly IFuelTypeManager _fuelTypeManager;
        private readonly IFuelTypeFieldCopier _fuelTypeFieldCopier;

        public FuelTypeController(IFuelTypeManager fuelTypeManager, IFuelTypeFieldCopier fuelTypeFieldCopier)
        {
            _fuelTypeManager = fuelTypeManager;
            _fuelTypeFieldCopier = fuelTypeFieldCopier;
        }

        // GET:
        public ActionResult List()
        {
            return View();
        }

        //GET 
        public ActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Create(FuelTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _fuelTypeManager.Add(_fuelTypeFieldCopier.CopyFields(model, new FuelType()));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            var dbItem = _fuelTypeManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            return View(_fuelTypeFieldCopier.CopyFields(dbItem, new FuelTypeViewModel()));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(FuelTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbItem = _fuelTypeManager.GetById(model.Id);
                if (dbItem == null) throw new NullReferenceException();
                dbItem = _fuelTypeFieldCopier.CopyFields(model, dbItem);
                _fuelTypeManager.Edit(dbItem);
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            var dbItem = _fuelTypeManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            _fuelTypeManager.Delete(dbItem);
            return RedirectToAction("List");
        }
    }
}