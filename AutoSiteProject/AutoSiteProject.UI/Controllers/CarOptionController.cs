using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using System;
using AutoSiteProject.Models.Bl.Interfaces.Managers;

namespace AutoSiteProject.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarOptionController : BaseController
    {
        private readonly ICarOptionManager _carOptionManager;
        private readonly ICarOptionFieldCopier _carOptionFieldCopier;
        public CarOptionController(ICarOptionManager carOptionManager, ICarOptionFieldCopier carOptionFieldCopier)
        {
            _carOptionManager = carOptionManager;
            _carOptionFieldCopier = carOptionFieldCopier;
        }

        // GET
        public ActionResult List()
        {
            var dbItems = _carOptionManager.GetAll().ToList();
            var result = dbItems.Select(item => _carOptionFieldCopier.CopyFields(item, new CarOptionViewModel())).ToList();
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
            if (dbItem == null) throw new NullReferenceException();
            return View(_carOptionFieldCopier.CopyFields(dbItem, new CarOptionViewModel()));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CarOptionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbItem = _carOptionManager.GetById(model.Id);
                if (dbItem == null) throw new NullReferenceException();
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
            if (dbItem == null) throw new NullReferenceException();
            _carOptionManager.Delete(dbItem);
            return RedirectToAction("List");
        }
    }
}