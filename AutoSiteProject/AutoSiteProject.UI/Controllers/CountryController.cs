using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSiteProject.UI.Controllers
{
    public class CountryController : Controller
    {
        private IRepositoryManager<CountryViewModel> _countryManager;

        public CountryController(IRepositoryManager<CountryViewModel> countryManager)
        {
            _countryManager = countryManager;
        }

        // GET: Country
        public ActionResult List()
        {
            return View(_countryManager.GetAll());
        }

        //GET 
        public ActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Create(CountryViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _countryManager.Add(entity);
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            return View(_countryManager.GetById(id));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CountryViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _countryManager.Edit(entity);
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            var entityForDelete = _countryManager.GetById(id);
            _countryManager.Delete(entityForDelete);
            return RedirectToAction("List");
        }

    }
}