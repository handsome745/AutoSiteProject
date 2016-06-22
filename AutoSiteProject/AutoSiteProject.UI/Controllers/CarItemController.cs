using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;

namespace AutoSiteProject.UI.Controllers
{
    public class CarItemController : Controller
    {
        private ICarItemManager _carItemManager;
        private ICarItemFieldCopier _carItemFieldCopier;

        public CarItemController(
            ICarItemManager carItemManager,
            ICarItemFieldCopier carItemFieldCopier
            )
        {
            _carItemManager = carItemManager;
            _carItemFieldCopier = carItemFieldCopier;
        }
        // GET
        public ActionResult List()
        {
            var dbItems = _carItemManager.GetAll().ToList();
            var result = new List<CarItemViewModel>();
            foreach (var item in dbItems)
            {
                result.Add(_carItemFieldCopier.CopyFields(item, new CarItemViewModel()));
            }
            return View(result);
        }

        //GET 
        public ActionResult Create(CarItemViewModel model)
        {
            return View(model);
        }
        //Post
        [HttpPost]
        public ActionResult CreateCar(CarItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                _carItemManager.Add(_carItemFieldCopier.CopyFields(model, new CarItem()));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            var dbItem = _carItemManager.GetById(id);
            return View(_carItemFieldCopier.CopyFields(dbItem, new CarItemViewModel()));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CarItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbItem = _carItemManager.GetById(model.Id);
                dbItem = _carItemFieldCopier.CopyFields(model, dbItem);
                _carItemManager.Edit(dbItem);
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            _carItemManager.Delete(_carItemManager.GetById(id));
            return RedirectToAction("List");
        }
    }
}