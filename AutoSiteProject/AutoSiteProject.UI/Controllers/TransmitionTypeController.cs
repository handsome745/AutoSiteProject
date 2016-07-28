using System;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TransmitionTypeController : Controller
    {
        private readonly ITransmitionTypeManager _transmitionTypeManager;
        private readonly ITransmitionTypeFieldCopier _transmitionTypeFieldCopier;

        public TransmitionTypeController(ITransmitionTypeManager transmitionTypeManager, ITransmitionTypeFieldCopier transmitionTypeFieldCopier)
        {
            _transmitionTypeManager = transmitionTypeManager;
            _transmitionTypeFieldCopier = transmitionTypeFieldCopier;
        }

        // GET:
        public ActionResult List()
        {
            return View();
        }

        //GET 
        public ActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Create(TransmitionTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _transmitionTypeManager.Add(_transmitionTypeFieldCopier.CopyFields(model, new TransmitionType()));
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            var dbItem = _transmitionTypeManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            return View(_transmitionTypeFieldCopier.CopyFields(dbItem, new TransmitionTypeViewModel()));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(TransmitionTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbItem = _transmitionTypeManager.GetById(model.Id);
                if (dbItem == null) throw new NullReferenceException();
                dbItem = _transmitionTypeFieldCopier.CopyFields(model, dbItem);
                _transmitionTypeManager.Edit(dbItem);
                return RedirectToAction("List");
            }
            return View(model);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            var dbItem = _transmitionTypeManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            _transmitionTypeManager.Delete(dbItem);
            return RedirectToAction("List");
        }
    }
}