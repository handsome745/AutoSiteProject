using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoSiteProject.Bl.Managers;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.ViewModels;
using LinqKit;

namespace AutoSiteProject.UI.Controllers
{
    [RequireHttps]
    public class HomeController : BaseController
    {
        private readonly ICarItemManager _carItemManager;
        private readonly ICarOptionManager _carOptionManager;
        private readonly ICarOptionFieldCopier _carOptionFieldCopier;

        public HomeController(
            ICarItemManager carItemManager,
            ICarOptionManager carOptionManager,
            ICarOptionFieldCopier carOptionFieldCopier)
        {
            _carItemManager = carItemManager;
            _carOptionManager = carOptionManager;
            _carOptionFieldCopier = carOptionFieldCopier;
        }

        // GET: Home
        public ActionResult Index(CarAggregateFilterViewModel filter)
        {
            if (filter == null) filter = new CarAggregateFilterViewModel();
            List<CarAggregateViewModel> carsList = _carItemManager.GetCarsAggregateViewModel(filter);
            foreach (var co in _carOptionManager.GetAll())
            {
                filter.AvalibleCarOptions.Add(_carOptionFieldCopier.CopyFields(co, new CarOptionViewModel()));
            }
            ViewBag.CarFilter = filter;
            return View(carsList);
        }
        [HttpPost]
        public ActionResult GetCars(CarAggregateFilterViewModel filter)
        {
            if (filter == null) throw new NullReferenceException();
            return RedirectToAction("Index", filter);
        }
    }
}