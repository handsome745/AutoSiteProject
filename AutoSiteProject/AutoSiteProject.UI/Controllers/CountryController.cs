using AutoMapper;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AutoSiteProject.UI.Controllers
{
    public class CountryController : Controller
    {
        private ICountryManager _countryManager;

        public CountryController(ICountryManager countryManager)
        {
            _countryManager = countryManager;
        }

        // GET: Country
        public ActionResult List()
        {
            return View(Mapper.Map<List<CountryViewModel>>(_countryManager.GetAll().ToList()));
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
                _countryManager.Add(Mapper.Map < Country>(model));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<CountryViewModel>(_countryManager.GetById(id)));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                _countryManager.Edit(Mapper.Map<Country>(model));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            _countryManager.Delete(id);
            return RedirectToAction("List");
        }

    }
}