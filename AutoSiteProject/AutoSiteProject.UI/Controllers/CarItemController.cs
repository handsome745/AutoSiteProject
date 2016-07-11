using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using System;
using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.UI.Hubs;

namespace AutoSiteProject.UI.Controllers
{
    public class CarItemController : BaseController
    {
        private readonly ICarItemManager _carItemManager;
        private readonly ICarItemFieldCopier _carItemFieldCopier;
        private readonly ICarOptionManager _carOptionsManager;
        private readonly ICarOptionFieldCopier _carOptionFieldCopier;
        public CarItemController(
            ICarItemManager carItemManager,
            ICarItemFieldCopier carItemFieldCopier,
            ICarOptionManager carOptionsManager,
            ICarOptionFieldCopier carOptionFieldCopier
            )
        {
            _carItemManager = carItemManager;
            _carItemFieldCopier = carItemFieldCopier;
            _carOptionsManager = carOptionsManager;
            _carOptionFieldCopier = carOptionFieldCopier;
        }
        // GET
        public ActionResult List()
        {
            return View();
        }

        //GET 
        public ActionResult Create(CarItemViewModel model)
        {

            var dbOptions = _carOptionsManager.GetAll().ToList();
            foreach (var item in dbOptions)
            {
                model.AvalibleCarOptions.Add(_carOptionFieldCopier.CopyFields(item, new CarOptionViewModel()));
            }
            ModelState.Clear();
            return View(model);
        }
        //Post
        [HttpPost]
        public ActionResult CreateCar(CarItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbItem = _carItemFieldCopier.CopyFields(model, new CarItem());
                _carItemManager.Add(dbItem);
                NotificationsHub.SendInfoMessage("Added new car!!!");//:"+ dbItem.CarModel +" Manufacturer:"+ dbItem.CarModel.Manufacturer);
                return RedirectToAction("List");
            }
            return View("Create", model);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            var dbItem = _carItemManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            var result = _carItemFieldCopier.CopyFields(dbItem, new CarItemViewModel());
            var dbOptions = _carOptionsManager.GetAll().ToList();
            foreach (var item in dbOptions)
            {
                result.AvalibleCarOptions.Add(_carOptionFieldCopier.CopyFields(item, new CarOptionViewModel()));
            }
            return View(result);
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CarItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbItem = _carItemManager.GetById(model.Id);
                if (dbItem == null) throw new NullReferenceException();
                dbItem = _carItemFieldCopier.CopyFields(model, dbItem);
                _carItemManager.Edit(dbItem);
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            var dbItem = _carItemManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            _carItemManager.Delete(dbItem);
            return RedirectToAction("List");
        }
    }
}