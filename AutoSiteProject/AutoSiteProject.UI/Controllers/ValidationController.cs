using AutoSiteProject.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using AutoSiteProject.Models.Bl.Interfaces.Managers;

namespace AutoSiteProject.UI.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : BaseController
    {
        private readonly ICarModelManager _carModelManager;
        private readonly IManufacturerManager _manufacturerManager;
        private readonly ICountryManager _countryManager;
        private readonly ICarBodyTypeManager _carBodyTypeManager;
        private readonly ICarOptionManager _carOptionManager;

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
            model.Name = model.Name.TrimStart(' ');
            model.Name = model.Name.TrimEnd(' ');
            return Json(_countryManager.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).ToList().Count <= 0, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChecManufacturerNameForExist(ManufacturerViewModel model)
        {
            model.Name = model.Name.TrimStart(' ');
            model.Name = model.Name.TrimEnd(' ');
            return Json(_manufacturerManager.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id && c.CountryId == model.CountryId).ToList().Count <= 0, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckBodyTypeNameForExist(CarBodyTypeViewModel model)
        {
            model.Name = model.Name.TrimStart(' ');
            model.Name = model.Name.TrimEnd(' ');
            return Json(_carBodyTypeManager.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).ToList().Count <= 0, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChecCarOptionNameForExist(CarOptionViewModel model)
        {
            model.Name = model.Name.TrimStart(' ');
            model.Name = model.Name.TrimEnd(' ');
            return Json(_carOptionManager.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).ToList().Count <= 0, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckCarModelNameForExist(CarModelViewModel model)
        {
            model.Name = model.Name.TrimStart(' ');
            model.Name = model.Name.TrimEnd(' ');
            return Json(_carModelManager.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id && c.ManufacturerId == model.ManufacturerId).ToList().Count <= 0, JsonRequestBehavior.AllowGet);
        }

    }
}