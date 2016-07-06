using System.Collections.Generic;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.UI.Controllers
{
    [RequireHttps]
    public class HomeController : BaseController
    {
        private readonly ICarOptionManager _carOptionManager;
        private readonly ICarOptionFieldCopier _carOptionFieldCopier;

        public HomeController(
            ICarOptionManager carOptionManager,
            ICarOptionFieldCopier carOptionFieldCopier)
        {
            _carOptionManager = carOptionManager;
            _carOptionFieldCopier = carOptionFieldCopier;
        }

        // GET: Home
        public ActionResult Index(CarAggregateFilterViewModel filter)
        {
            if (filter == null) filter = new CarAggregateFilterViewModel();
            foreach (var co in _carOptionManager.GetAll())
            {
                filter.AvalibleCarOptions.Add(_carOptionFieldCopier.CopyFields(co, new CarOptionViewModel()));
            }
            ViewBag.CarFilter = filter;
            return View(new List<CarAggregateViewModel>());
        }
    }
}