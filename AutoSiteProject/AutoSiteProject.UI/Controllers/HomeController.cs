using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoSiteProject.Bl.Managers;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.ViewModels;
using LinqKit;

namespace AutoSiteProject.UI.Controllers
{
    [RequireHttps]
    public class HomeController : BaseController
    {
        private readonly ICarItemManager _carItemManager;

        public HomeController(ICarItemManager carItemManager)
        {
            _carItemManager = carItemManager;
        }

        // GET: Home
        public ActionResult Index(CarAggregateFilterViewModel filter)
        {
            List<CarAggregateViewModel> carsList = new List<CarAggregateViewModel>();
            var carDbList = _carItemManager.GetAll();
            foreach (var car in carDbList)
            {
                carsList.Add(new CarAggregateViewModel
                {
                    CarId = car.Id,
                    Country = car.CarModel.Manufacturer.Country.Name,
                    Manufacturer = car.CarModel.Manufacturer.Name,
                    Model = car.CarModel.Name,
                    BodyType = car.CarBodyType.Name,
                    Description = car.Description,
                    Options = car.CarOption.Select(o=> o.Name).ToList()
            });
        }

            return View(carsList);
    }



}
}