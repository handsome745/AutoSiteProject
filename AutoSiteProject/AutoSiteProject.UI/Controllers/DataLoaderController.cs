using AutoMapper;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSiteProject.UI.Controllers
{
    public class DataLoaderController : Controller
    {
        private ICarModelManager _carModelManager;
        private IManufacturerManager _manufacturerManager;
        private ICountryManager _countryManager;
        private ICarBodyTypeManager _carBodyTypeManager;
        private ICarOptionManager _carOptionManager;

        public DataLoaderController(ICarModelManager carModelManager,
            IManufacturerManager manufacturerManager,
            ICountryManager countryManager,
            ICarBodyTypeManager carBodyTypeManager,
            ICarOptionManager carOptionManager)
        {
            _carModelManager = carModelManager;
            _manufacturerManager = manufacturerManager;
            _countryManager = countryManager;
            _carBodyTypeManager = carBodyTypeManager;
            _carOptionManager = carOptionManager;
        }

        public JsonResult GetManufacturersOfCountry(int id)
        {
            var result = Mapper.Map<List<ManufacturerViewModel>>(_manufacturerManager.GetAll().Where(m => m.CountryId == id).ToList());
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCarModelsOfManufacturer(int id)
        {
            var result = Mapper.Map<List<CarModelViewModel>>(_carModelManager.GetAll().Where(m => m.ManufacturerId == id).ToList());
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBodyTypesOfCarModel(int id)
        {
            var result = _carBodyTypeManager.GetAll().Where(cbt => cbt.CarModel.Any(cm => cm.Id == id)).ToList();
            return Json(Mapper.Map<List<CarBodyTypeViewModel>>(result.ToList()), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOptionsOfCarItem(int id)
        {
            var result = _carOptionManager.GetAll().Where(co => co.CarItem.Any(ci => ci.Id == id)).ToList();
            return Json(Mapper.Map<List<CarOptionViewModel>>(result.ToList()), JsonRequestBehavior.AllowGet);
        }

    }
}