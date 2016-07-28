using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using System;
using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.UI.Hubs;
using System.Web;
using System.Collections.Generic;
using System.Security;
using Microsoft.AspNet.Identity;

namespace AutoSiteProject.UI.Controllers
{
    [Authorize]
    public class CarItemController : BaseController
    {
        private readonly ICarItemManager _carItemManager;
        private readonly ICarItemFieldCopier _carItemFieldCopier;
        private readonly ICarOptionManager _carOptionsManager;
        private readonly ICarOptionFieldCopier _carOptionFieldCopier;
        private readonly ICarImageManager _carImageManager;
        private readonly ICarImageFieldCopier _carImageFieldCopier;

        public CarItemController(
            ICarItemManager carItemManager,
            ICarItemFieldCopier carItemFieldCopier,
            ICarOptionManager carOptionsManager,
            ICarOptionFieldCopier carOptionFieldCopier,
            ICarImageManager carImageManager,
            ICarImageFieldCopier carImageFieldCopier
            )
        {
            _carItemManager = carItemManager;
            _carItemFieldCopier = carItemFieldCopier;
            _carOptionsManager = carOptionsManager;
            _carOptionFieldCopier = carOptionFieldCopier;
            _carImageManager = carImageManager;
            _carImageFieldCopier = carImageFieldCopier;
        }

        // GET
        [AllowAnonymous]
        public ActionResult List()
        {
            return View();
        }

        
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

        private void SaveImagesAndLink(CarItem dbModel, IEnumerable<HttpPostedFileBase> files)
        {
            //save images into db
            if (files == null) return;
            foreach (var file in files)
            {
                if (file == null || file.ContentLength <= 0) continue;
                var image = new CarImages
                {
                    Name = file.FileName,
                    ContentLength = file.ContentLength,
                    ContentType = file.ContentType,
                    Data = new byte[file.ContentLength]
                };
                file.InputStream.Read(image.Data, 0, (int)image.ContentLength);//Warning!!!
                _carImageManager.Add(image);//save image to db
                dbModel.CarImages.Add(image); //add link to CarItem 
            }
        }

        //Post
        [HttpPost]
        public ActionResult CreateCar(CarItemViewModel model, List<HttpPostedFileBase> files)
        {
            var userId = User.Identity.GetUserId();
            if (!ModelState.IsValid) return View("Create", model);
            var dbItem = _carItemFieldCopier.CopyFields(model, new CarItem());
            SaveImagesAndLink(dbItem, files);

            dbItem.OwnerId = userId;
            dbItem.LastEditorId = userId;
            dbItem.EditDate = DateTime.Now;
            dbItem.Status = (int)CarItemStatus.Open;

            //add new car into db
            _carItemManager.Add(dbItem);
            //notify all users
            NotificationsHub.SendInfoMessage("Added new car!!!");//:"+ dbItem.CarModel +" Manufacturer:"+ dbItem.CarModel.Manufacturer);
            return RedirectToAction("List");
        }

        //GET 
        public ActionResult Edit(int id)
        {
            var dbItem = _carItemManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();

            if (!User.IsInRole("Admin"))
            {
                var userId = User.Identity.GetUserId();
                if (dbItem.OwnerId != userId) throw new SecurityException();
            }

            var result = _carItemFieldCopier.CopyFields(dbItem, new CarItemViewModel());
            foreach (var image in dbItem.CarImages)
            {
                result.Images.Add(_carImageFieldCopier.CopyFields(image, new CarImageViewModel()));//copy all without data
            }
            var dbOptions = _carOptionsManager.GetAll().ToList();
            foreach (var item in dbOptions)
            {
                result.AvalibleCarOptions.Add(_carOptionFieldCopier.CopyFields(item, new CarOptionViewModel()));
            }
            return View(result);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var dbItem = _carItemManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();

            var result = _carItemFieldCopier.CopyFields(dbItem, new CarItemViewModel());
            foreach (var image in dbItem.CarImages)
            {
                var img = _carImageFieldCopier.CopyFields(image, new CarImageViewModel());
                img.Data = image.Data;
                result.Images.Add(img);

            }
            return View(result);
        }

        //Post
        [HttpPost]
        public ActionResult Edit(CarItemViewModel model, List<HttpPostedFileBase> files)
        {
            if (!ModelState.IsValid) return View(model);
            var userId = User.Identity.GetUserId();
            var dbItem = _carItemManager.GetById(model.Id);
            if (dbItem == null) throw new NullReferenceException();
            if (!User.IsInRole("Admin"))
            {
                if (dbItem.OwnerId != userId) throw new SecurityException();
            }
            //delete disabled images
            var dbImagesIds = dbItem.CarImages.Select(x => x.Id);
            var modelImagesIds = model.Images.Select(x => x.Id);
            var imagesIdsForDelete = dbImagesIds.Except(modelImagesIds);
            DeleteImages(dbItem, imagesIdsForDelete);
            //add new images
            SaveImagesAndLink(dbItem, files);
            //copy edited fields
            dbItem = _carItemFieldCopier.CopyFields(model, dbItem);
            //save changes
            dbItem.LastEditorId = userId;
            dbItem.EditDate = DateTime.Now;
            _carItemManager.Edit(dbItem);
            return RedirectToAction("List");
        }

        private void DeleteImages(CarItem dbItem, IEnumerable<int> ids)
        {
            var dbImagesArrayForDelete = dbItem.CarImages.Where(x => ids.Contains(x.Id)).ToList();
            foreach (var item in dbImagesArrayForDelete)
            {
                //remove from dbitem
                dbItem.CarImages.Remove(item);
                //remove from database
                _carImageManager.Delete(item);
            }
        }

        //GET 
        public ActionResult Delete(int id)
        {
            var dbItem = _carItemManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            if (!User.IsInRole("Admin"))
            {
                var userId = User.Identity.GetUserId();
                if (dbItem.OwnerId != userId) throw new SecurityException();
            }
            _carItemManager.Delete(dbItem);
            return RedirectToAction("List");
        }
        //GET 
        public ActionResult SetStatusToClose(int id)
        {
            var authUserId = User.Identity.GetUserId();
            var dbItem = _carItemManager.GetById(id);
            if (dbItem == null) throw new NullReferenceException();
            if (!User.IsInRole("Admin"))
            {
                var userId = authUserId;
                if (dbItem.OwnerId != userId) throw new SecurityException();
            }
            dbItem.LastEditorId = authUserId;
            dbItem.EditDate = DateTime.Now;
            dbItem.Status = (int)CarItemStatus.Close;
            _carItemManager.Edit(dbItem);
            return RedirectToAction("List");
        }
    }
}