using AutoSiteProject.Models.Bl.Interfaces;
using System.Linq;
using System.Web.Mvc;
using AutoSiteProject.Models.ViewModels;
using System.Collections.Generic;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;

namespace AutoSiteProject.UI.Controllers
{
    public class DataLoaderController : Controller
    {
        private ICarModelManager _carModelManager;
        private IManufacturerManager _manufacturerManager;
        private ICountryManager _countryManager;
        private ICarBodyTypeManager _carBodyTypeManager;
        private ICarOptionManager _carOptionManager;

        private ICarModelFieldCopier _carModelFieldCopier;
        private IManufacturerFieldCopier _manufacturerFieldCopier;
        private ICountryFieldCopier _countryFieldCopier;
        private ICarBodyTypeFieldCopier _carBodyTypeFieldCopier;
        private ICarOptionFieldCopier _carOptionFieldCopier;


        public DataLoaderController(
            ICarModelManager carModelManager,
            IManufacturerManager manufacturerManager,
            ICountryManager countryManager,
            ICarBodyTypeManager carBodyTypeManager,
            ICarOptionManager carOptionManager,
            ICarModelFieldCopier carModelFieldCopier,
            IManufacturerFieldCopier manufacturerFieldCopier,
            ICountryFieldCopier countryFieldCopier,
            ICarBodyTypeFieldCopier carBodyTypeFieldCopier,
            ICarOptionFieldCopier carOptionFieldCopier
            )
        {
            _carModelManager = carModelManager;
            _manufacturerManager = manufacturerManager;
            _countryManager = countryManager;
            _carBodyTypeManager = carBodyTypeManager;
            _carOptionManager = carOptionManager;

            _carModelFieldCopier = carModelFieldCopier;
            _manufacturerFieldCopier = manufacturerFieldCopier;
            _countryFieldCopier = countryFieldCopier;
            _carBodyTypeFieldCopier = carBodyTypeFieldCopier;
            _carOptionFieldCopier = carOptionFieldCopier;
        }

        public JsonResult GetCountries()
        {

            var dbItems = _countryManager.GetAll().ToList();
            var result = new List<CountryViewModel>();
            foreach (var item in dbItems)
            {
                result.Add(_countryFieldCopier.CopyFields(item, new CountryViewModel()));
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetManufacturersOfCountry(int id)
        {
            var dbItems = _manufacturerManager.GetAll().Where(m => m.CountryId == id).ToList();
            var result = new List<ManufacturerViewModel>();
            foreach (var item in dbItems)
            {
                result.Add(_manufacturerFieldCopier.CopyFields(item, new ManufacturerViewModel()));
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCarModelsOfManufacturer(int id)
        {
            var dbItems = _carModelManager.GetAll().Where(m => m.ManufacturerId == id).ToList();
            var result = new List<CarModelViewModel>();
            foreach (var item in dbItems)
            {
                result.Add(_carModelFieldCopier.CopyFields(item, new CarModelViewModel()));
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBodyTypes()
        {
            var dbItems = _carBodyTypeManager.GetAll().ToList();
            var result = new List<CarBodyTypeViewModel>();
            foreach (var item in dbItems)
            {
                result.Add(_carBodyTypeFieldCopier.CopyFields(item, new CarBodyTypeViewModel()));
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOptionsOfCarItem(int id)
        {
            var dbItems = _carOptionManager.GetAll().Where(co => co.CarItem.Any(ci => ci.Id == id)).ToList();
            var result = new List<CarOptionViewModel>();
            foreach (var item in dbItems)
            {
                result.Add(_carOptionFieldCopier.CopyFields(item, new CarOptionViewModel()));
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCarOptions()
        {
            var dbItems = _carOptionManager.GetAll().ToList();
            var result = new List<CarOptionViewModel>();
            foreach (var item in dbItems)
            {
                result.Add(_carOptionFieldCopier.CopyFields(item, new CarOptionViewModel()));
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}