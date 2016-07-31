using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoSiteProject.Models.ViewModels;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.Bl.IdentityClasses;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

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
        private readonly IRoleFieldCopier _roleFieldCopier;
        private readonly IUserFieldCopier _userFieldCopier;
        private readonly ICarImageManager _carImageManager;
        private readonly IFuelTypeManager _fuelTypeManager;
        private readonly IFuelTypeFieldCopier _fuelTypeFieldCopier;
        private readonly ITransmitionTypeManager _transmitionTypeManager;
        private readonly ITransmitionTypeFieldCopier _transmitionTypeFieldCopier;

        public ApplicationRoleManager RoleManager => HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
        public  ApplicationUserManager UserManager => HttpContext.GetOwinContext().Get<ApplicationUserManager>();

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
            ICarItemManager carItemManager,
            IRoleFieldCopier roleFieldCopier,
            ICarImageManager carImageManage,
            IUserFieldCopier userFieldCopier, 
            IFuelTypeManager fuelTypeManager,
            IFuelTypeFieldCopier fuelTypeFieldCopier,
            ITransmitionTypeManager transmitionTypeManager,
            ITransmitionTypeFieldCopier transmitionTypeFieldCopier
            )
        {
            _carModelManager = carModelManager;
            _manufacturerManager = manufacturerManager;
            _countryManager = countryManager;
            _carBodyTypeManager = carBodyTypeManager;
            _carOptionManager = carOptionManager;
            _carImageManager = carImageManage;
            _carModelFieldCopier = carModelFieldCopier;
            _manufacturerFieldCopier = manufacturerFieldCopier;
            _countryFieldCopier = countryFieldCopier;
            _carBodyTypeFieldCopier = carBodyTypeFieldCopier;
            _carOptionFieldCopier = carOptionFieldCopier;
            _carItemManager = carItemManager;
            _roleFieldCopier = roleFieldCopier;
            _userFieldCopier = userFieldCopier;
            _fuelTypeManager = fuelTypeManager;
            _fuelTypeFieldCopier = fuelTypeFieldCopier;
            _transmitionTypeManager = transmitionTypeManager;
            _transmitionTypeFieldCopier = transmitionTypeFieldCopier;
        }
        [HttpPost]
        public JsonResult GetCars(CarAggregateFilterViewModel filter)
        {
            if (filter == null) filter = new CarAggregateFilterViewModel();
            var carsList = _carItemManager.GetCarsAggregateViewModel(filter).Take(5);
            //filter result by status
            var thisIsAdmin = User.IsInRole("Admin");
            carsList = carsList.Where(r => r.Status == CarItemStatus.Open || thisIsAdmin).ToList();
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
        public JsonResult GetFuelTypes()
        {
            var dbItems = _fuelTypeManager.GetAll().ToList();
            var result = dbItems.Select(item => _fuelTypeFieldCopier.CopyFields(item, new FuelTypeViewModel())).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTransmitionTypes()
        {
            var dbItems = _transmitionTypeManager.GetAll().ToList();
            var result = dbItems.Select(item => _transmitionTypeFieldCopier.CopyFields(item, new TransmitionTypeViewModel())).ToList();
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

        public ActionResult GetCarsPartial(CarAggregateFilterViewModel filter)
        {
            var carsList = _carItemManager.GetCarsAggregateViewModel(filter);
            //filter result by status
            var thisIsAdmin = User.IsInRole("Admin");
            carsList = carsList.Where(r => r.Status == CarItemStatus.Open || thisIsAdmin).ToList();
            return PartialView("CarsGridViewPartial", carsList);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetCarBodyTypesPartial()
        {
            var dbItems = _carBodyTypeManager.GetAll().ToList();
            var result = dbItems.Select(item => _carBodyTypeFieldCopier.CopyFields(item, new CarBodyTypeViewModel())).ToList();
            return PartialView("GetCarBodyTypesPartial", result);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetCarModelsPartial()
        {
            var dbItems = _carModelManager.GetAll();
            var result = dbItems.Select(item => _carModelFieldCopier.CopyFields(item, new CarModelViewModel())).ToList();
            return PartialView("GetCarModelsPartial", result);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetCarOptionsPartial()
        {
            var dbItems = _carOptionManager.GetAll();
            var result = dbItems.Select(item => _carOptionFieldCopier.CopyFields(item, new CarOptionViewModel())).ToList();
            return PartialView("GetCarOptionsPartial", result);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetCountriesPartial()
        {
            var dbItems = _countryManager.GetAll();
            var result = dbItems.Select(item => _countryFieldCopier.CopyFields(item, new CountryViewModel())).ToList();
            return PartialView("GetCountriesPartial", result);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetManufacturersPartial()
        {
            var dbItems = _manufacturerManager.GetAll();
            var result = dbItems.Select(item => _manufacturerFieldCopier.CopyFields(item, new ManufacturerViewModel())).ToList();
            return PartialView("GetManufacturersPartial", result);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetRolesPartial()
        {
            var dbRoles = RoleManager.Roles.ToList();
            var result = dbRoles.Select(r => _roleFieldCopier.CopyFields(r, new RoleViewModel())).ToList();
            return PartialView("GetRolesPartial", result);
        }
        public ActionResult GetCarItemsPartial()
        {
            var filter = new CarAggregateFilterViewModel
            {
                PriceMax = int.MaxValue,
                ReleaseYearMax = int.MaxValue,
                VolumeMax = int.MaxValue
            };
            var result = _carItemManager.GetCarsAggregateViewModel(filter);
            //filter result by status
            var thisIsAdmin = User.IsInRole("Admin");
            result = result.Where(r => r.Status == CarItemStatus.Open || thisIsAdmin).ToList();
            return PartialView("GetCarItemsPartial", result);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetUsersPartial()
        {
            var usersViewModels = new List<UserViewModel>();
            var dbUsers = UserManager.Users.ToList();
            foreach (var u in dbUsers)
            {
                var q = _userFieldCopier.CopyFields(u, new UserViewModel());
                for (int i = 0; i < q.SelectedRoles.Length; i++)
                {
                    q.SelectedRoles[i] =  RoleManager.FindById(q.SelectedRoles[i]).Name;
                }
                usersViewModels.Add(q);
            }
            return PartialView("GetUsersPartial", usersViewModels);
        }
        public ActionResult LoadImg(int? id)
        {
            if (id == null) return null;
            var image = _carImageManager.GetById((int)id);
            return File(image.Data, image.ContentType, image.Name);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetFuelTypePartial()
        {
             var dbItems = _fuelTypeManager.GetAll().ToList();
            var result = dbItems.Select(item => _fuelTypeFieldCopier.CopyFields(item, new FuelTypeViewModel())).ToList();
            return PartialView("GetFuelTypePartial", result);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetTransmitionTypePartial()
        {
            var dbItems = _transmitionTypeManager.GetAll().ToList();
            var result = dbItems.Select(item => _transmitionTypeFieldCopier.CopyFields(item, new TransmitionTypeViewModel())).ToList();
            return PartialView("GetTransmitionTypePartial", result);
        }

        [Authorize]
        public ActionResult MyCarsListPartial(string id)
        {
            CarAggregateFilterViewModel filter = new CarAggregateFilterViewModel
            {
                PriceMax = int.MaxValue,
                ReleaseYearMax = int.MaxValue,
                VolumeMax = int.MaxValue,
                OwnerId = id
            };

            var myCarList = _carItemManager.GetCarsAggregateViewModel(filter);
            return PartialView("MyCarsListPartial", myCarList);
        }


    }
}