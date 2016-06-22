using System;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class CarItemFieldCopier : ICarItemFieldCopier
    {
        private ICarModelFieldCopier _carModelFieldCopier;
        private ICarBodyTypeFieldCopier _carBodyTypeFieldCopier;
        private IManufacturerFieldCopier _manufacturerFieldCopier;

        public CarItemFieldCopier(ICarModelFieldCopier carModelFieldCopier,
            ICarBodyTypeFieldCopier carBodyTypeFieldCopier,
            IManufacturerFieldCopier manufacturerFieldCopier)
        {
            _carModelFieldCopier = carModelFieldCopier;
            _carBodyTypeFieldCopier = carBodyTypeFieldCopier;
            _manufacturerFieldCopier = manufacturerFieldCopier;
        }

        public CarItemViewModel CopyFields(CarItem from, CarItemViewModel to)
        {
            if (to == null) to = new CarItemViewModel();
            to.Id = from.Id;
            to.BodyTypeId = from.BodyTypeId;
            to.ModelId = from.ModelId;
            to.Description = from.Description;
            to.CarModel = _carModelFieldCopier.CopyFields(from.CarModel, to.CarModel);
            to.CarBodyType = _carBodyTypeFieldCopier.CopyFields(from.CarBodyType, to.CarBodyType);
            //to.Manufacturer = _manufacturerFieldCopier.CopyFields(from.CarModel.Manufacturer, to.Manufacturer);
            to.ManufacturerId = from.CarModel.ManufacturerId;
            to.CountryId = from.CarModel.Manufacturer.CountryId;
            //to.CarOption
            return to;
        }

        public CarItem CopyFields(CarItemViewModel from, CarItem to)
        {
            to.BodyTypeId = from.BodyTypeId;
            to.ModelId = from.ModelId;
            to.Description = from.Description;
            //to.CarOption
            return to;
        }
    }
}
