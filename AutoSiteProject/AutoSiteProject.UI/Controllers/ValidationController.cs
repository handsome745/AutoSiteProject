using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace AutoSiteProject.UI.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : Controller
    {
        private ICarModelManager _carModelManager;
        private IManufacturerManager _manufacturerManager;
        private ICountryManager _countryManager;
        private ICarBodyTypeManager _carBodyTypeManager;
        private ICarOptionManager _carOptionManager;

        public ValidationController(
            ICarModelManager carModelManager,
            IManufacturerManager manufacturerManager,
            ICountryManager countryManager,
            ICarBodyTypeManager carBodyTypeManager,
            ICarOptionManager carOptionManager
            )
        {
            _carModelManager = carModelManager;
            _manufacturerManager = manufacturerManager;
            _countryManager = countryManager;
            _carBodyTypeManager = carBodyTypeManager;
            _carOptionManager = carOptionManager;
        }

        // GET: Validation
        public JsonResult CheckCountryNameForExist(CountryViewModel model)
        {
            model.Name = model.Name.TrimStart(new char[] { ' ' });
            model.Name = model.Name.TrimEnd(new char[] { ' ' });
            if (_countryManager.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).ToList().Count > 0)
            return Json(false, JsonRequestBehavior.AllowGet);
            else return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChecManufacturerNameForExist(ManufacturerViewModel model)
        {
            model.Name = model.Name.TrimStart(new char[] { ' ' });
            model.Name = model.Name.TrimEnd(new char[] { ' ' });
            if (_manufacturerManager.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id && c.CountryId == model.CountryId).ToList().Count > 0)
                return Json(false, JsonRequestBehavior.AllowGet);
            else return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckBodyTypeNameForExist(CarBodyTypeViewModel model)
        {
            model.Name = model.Name.TrimStart(new char[] { ' ' });
            model.Name = model.Name.TrimEnd(new char[] { ' ' });
            if (_carBodyTypeManager.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).ToList().Count > 0)
                return Json(false, JsonRequestBehavior.AllowGet);
            else return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChecCarOptionNameForExist(CarOptionViewModel model)
        {
            model.Name = model.Name.TrimStart(new char[] { ' ' });
            model.Name = model.Name.TrimEnd(new char[] { ' ' });
            if (_carOptionManager.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).ToList().Count > 0)
                return Json(false, JsonRequestBehavior.AllowGet);
            else return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckCarModelNameForExist(CarModelViewModel model)
        {
            model.Name = model.Name.TrimStart(new char[] { ' ' });
            model.Name = model.Name.TrimEnd(new char[] { ' ' });
            if (_carModelManager.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id && c.ManufacturerId == model.ManufacturerId).ToList().Count > 0)
                return Json(false, JsonRequestBehavior.AllowGet);
            else return Json(true, JsonRequestBehavior.AllowGet);
        }
        
    }
}