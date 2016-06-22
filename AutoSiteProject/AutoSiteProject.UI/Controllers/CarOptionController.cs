using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;

namespace AutoSiteProject.UI.Controllers
{
    public class CarOptionController : Controller
    {
        private ICarOptionManager _carOptionManager;
        private ICarOptionFieldCopier _carOptionFieldCopier;
        public CarOptionController(ICarOptionManager carOptionManager, ICarOptionFieldCopier carOptionFieldCopier)
        {
            _carOptionManager = carOptionManager;
            _carOptionFieldCopier = carOptionFieldCopier;
        }

        // GET
        public ActionResult List()
        {
            var dbItems = _carOptionManager.GetAll().ToList();
            var result = new List<CarOptionViewModel>();
            foreach (var item in dbItems)
            {
                result.Add(_carOptionFieldCopier.CopyFields(item, new CarOptionViewModel()));
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
        public ActionResult Create(CarOptionViewModel model)
        {
            if (ModelState.IsValid)
            {
                _carOptionManager.Add(_carOptionFieldCopier.CopyFields(model, new CarOption()));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            var dbItem = _carOptionManager.GetById(id);
            return View(_carOptionFieldCopier.CopyFields(dbItem, new CarOptionViewModel()));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CarOptionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbItem = _carOptionManager.GetById(model.Id);
                dbItem = _carOptionFieldCopier.CopyFields(model, dbItem);
                _carOptionManager.Edit(dbItem);
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            var dbItem = _carOptionManager.GetById(id);
            _carOptionManager.Delete(dbItem);
            return RedirectToAction("List");
        }
    }
}