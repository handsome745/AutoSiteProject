using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using System;
using AutoSiteProject.Models.Bl.Interfaces.Managers;

namespace AutoSiteProject.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : BaseController
    {
        private readonly ICountryManager _countryManager;
        private readonly ICountryFieldCopier _countryFieldCopier;

        public CountryController(ICountryManager countryManager, ICountryFieldCopier countryFieldCopier)
        {
            _countryManager = countryManager;
            _countryFieldCopier = countryFieldCopier;
        }

        // GET: Country
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
        public ActionResult Create(CountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                _countryManager.Add(_countryFieldCopier.CopyFields(model, new Country()));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            var dbItem = _countryManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            return View(_countryFieldCopier.CopyFields(dbItem, new CountryViewModel()));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbItem = _countryManager.GetById(model.Id);
                if (dbItem == null) throw new NullReferenceException();
                dbItem = _countryFieldCopier.CopyFields(model, dbItem);
                _countryManager.Edit(dbItem);
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            var dbItem = _countryManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            _countryManager.Delete(dbItem);
            return RedirectToAction("List");
        }

    }
}