using System;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using AutoSiteProject.Models.Bl.Interfaces;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class CarItemFieldCopier : ICarItemFieldCopier
    {
        private ICarOptionManager _carOptionManager;
        private ICarModelFieldCopier _carModelFieldCopier;
        private ICarBodyTypeFieldCopier _carBodyTypeFieldCopier;
        private IManufacturerFieldCopier _manufacturerFieldCopier;

        public CarItemFieldCopier(
            ICarModelFieldCopier carModelFieldCopier,
            ICarBodyTypeFieldCopier carBodyTypeFieldCopier,
            IManufacturerFieldCopier manufacturerFieldCopier,
            ICarOptionManager carOptionManager)
        {
            _carModelFieldCopier = carModelFieldCopier;
            _carBodyTypeFieldCopier = carBodyTypeFieldCopier;
            _manufacturerFieldCopier = manufacturerFieldCopier;
            _carOptionManager = carOptionManager;
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

            to.SelectedCarOptions = new string[from.CarOption.Count];
            CarOption[] arrayCO = new CarOption[from.CarOption.Count];
            from.CarOption.CopyTo(arrayCO, 0);

            for (int i =0; i < from.CarOption.Count;i++)
            {
                to.SelectedCarOptions[i] = arrayCO[i].Id.ToString();
            }
            return to;
        }

        public CarItem CopyFields(CarItemViewModel from, CarItem to)
        {
            to.BodyTypeId = from.BodyTypeId;
            to.ModelId = from.ModelId;
            to.Description = from.Description;

            to.CarOption.Clear();
            if (from.SelectedCarOptions != null)
            foreach(string s in from.SelectedCarOptions)
            {
                int id;
                if (Int32.TryParse(s, out id))
                {
                    to.CarOption.Add(_carOptionManager.GetById(id));
                }
            }
            return to;
        }
    }
}
