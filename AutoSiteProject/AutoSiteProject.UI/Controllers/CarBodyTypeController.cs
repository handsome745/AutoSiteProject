using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.ViewModels;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.UI.Controllers
{
    public class CarBodyTypeController : BaseController
    {
        private ICarBodyTypeManager _carBodyTypeManager;
        private ICarBodyTypeFieldCopier _carBodyTypeFieldCopier;

        public CarBodyTypeController(ICarBodyTypeManager carBodyTypeManager, ICarBodyTypeFieldCopier carBodyTypeFieldCopier)
        {
            _carBodyTypeManager = carBodyTypeManager;
            _carBodyTypeFieldCopier = carBodyTypeFieldCopier;
        }

        // GET: CarModel
        public ActionResult List()
        {
            var dbItems = _carBodyTypeManager.GetAll().ToList();
            var result = new List<CarBodyTypeViewModel>();
            foreach (var item in dbItems)
            {
                result.Add(_carBodyTypeFieldCopier.CopyFields(item, new CarBodyTypeViewModel()));
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
        public ActionResult Create(CarBodyTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _carBodyTypeManager.Add(_carBodyTypeFieldCopier.CopyFields(model, new CarBodyType()));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            var dbItem = _carBodyTypeManager.GetById(id);
            return View(_carBodyTypeFieldCopier.CopyFields(dbItem,new CarBodyTypeViewModel()));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CarBodyTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbItem = _carBodyTypeManager.GetById(model.Id);
                dbItem = _carBodyTypeFieldCopier.CopyFields(model, dbItem);
                _carBodyTypeManager.Edit(dbItem);
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            var dbItem = _carBodyTypeManager.GetById(id);
            _carBodyTypeManager.Delete(dbItem);
            return RedirectToAction("List");
        }
    }
}