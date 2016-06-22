using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;

namespace AutoSiteProject.UI.Controllers
{
    public class CountryController : Controller
    {
        private ICountryManager _countryManager;
        private ICountryFieldCopier _countryFieldCopier;

        public CountryController(ICountryManager countryManager, ICountryFieldCopier countryFieldCopier)
        {
            _countryManager = countryManager;
            _countryFieldCopier = countryFieldCopier;
        }

        // GET: Country
        public ActionResult List()
        {
            var dbItems = _countryManager.GetAll().ToList();
            var result = new List<CountryViewModel>();
            foreach (var item in dbItems)
            {
                result.Add(_countryFieldCopier.CopyFields(item, new CountryViewModel()));
            }
            return View(result);
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
            return View(_countryFieldCopier.CopyFields(dbItem, new CountryViewModel()));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbItem = _countryManager.GetById(model.Id);
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
            _countryManager.Delete(dbItem);
            return RedirectToAction("List");
        }

    }
}