using System.Linq;
using System.Web.Mvc;
using AutoSiteProject.Models.ViewModels;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.Bl.Interfaces.Managers;
using System.Web.Script.Serialization;

namespace AutoSiteProject.UI.Controllers
{
    public class DataLoaderController : BaseController
    {
        private readonly ICarModelManager _carModelManager;
        private readonly IManufacturerManager _manufacturerManager;
        private readonly ICountryManager _countryManager;
        private readonly ICarBodyTypeManager _carBodyTypeManager;
        private readonly ICarOptionManager _carOptionManager;

        private readonly ICarModelFieldCopier _carModelFieldCopier;
        private readonly IManufacturerFieldCopier _manufacturerFieldCopier;
        private readonly ICountryFieldCopier _countryFieldCopier;
        private readonly ICarBodyTypeFieldCopier _carBodyTypeFieldCopier;
        private readonly ICarOptionFieldCopier _carOptionFieldCopier;
        private readonly ICarItemManager _carItemManager;

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
            ICarOptionFieldCopier carOptionFieldCopier,
            ICarItemManager carItemManager
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
            _carItemManager = carItemManager;
        }
        [HttpPost]
        public JsonResult GetCars(CarAggregateFilterViewModel filter)
        {
            if (filter == null) filter = new CarAggregateFilterViewModel();
            var carsList = _carItemManager.GetCarsAggregateViewModel(filter);
            return Json(carsList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCountries()
        {

            var dbItems = _countryManager.GetAll().ToList();
            var result = dbItems.Select(item => _countryFieldCopier.CopyFields(item, new CountryViewModel())).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetManufacturersOfCountry(int id)
        {
            var dbItems = _manufacturerManager.GetAll().Where(m => m.CountryId == id).ToList();
            var result = dbItems.Select(item => _manufacturerFieldCopier.CopyFields(item, new ManufacturerViewModel())).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCarModelsOfManufacturer(int id)
        {
            var dbItems = _carModelManager.GetAll().Where(m => m.ManufacturerId == id).ToList();
            var result = dbItems.Select(item => _carModelFieldCopier.CopyFields(item, new CarModelViewModel())).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBodyTypes()
        {
            var dbItems = _carBodyTypeManager.GetAll().ToList();
            var result = dbItems.Select(item => _carBodyTypeFieldCopier.CopyFields(item, new CarBodyTypeViewModel())).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOptionsOfCarItem(int id)
        {

            var dbItems = _carOptionManager.GetAll().Where(co => co.CarItem.Any(ci => ci.Id == id)).ToList();
            var result = dbItems.Select(item => _carOptionFieldCopier.CopyFields(item, new CarOptionViewModel())).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCarOptions()
        {
            var dbItems = _carOptionManager.GetAll().ToList();
            var result = dbItems.Select(item => _carOptionFieldCopier.CopyFields(item, new CarOptionViewModel())).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCarsPartial()
        {
            var jss = new JavaScriptSerializer();
            var parameters = Request.Params["filter"] ?? "";
            var filter = jss.Deserialize<CarAggregateFilterViewModel>(parameters) ??
                         new CarAggregateFilterViewModel();
            var carsList = _carItemManager.GetCarsAggregateViewModel(filter);
            return PartialView("_CarsGridViewPartial",carsList);
        }
    }
}