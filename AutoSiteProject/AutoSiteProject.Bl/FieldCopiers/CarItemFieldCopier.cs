using System;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using AutoSiteProject.Models.Bl.Interfaces.Managers;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class CarItemFieldCopier : ICarItemFieldCopier
    {
        private readonly ICarOptionManager _carOptionManager;
        private readonly ICarModelFieldCopier _carModelFieldCopier;
        private readonly ICarBodyTypeFieldCopier _carBodyTypeFieldCopier;

        public CarItemFieldCopier(
            ICarModelFieldCopier carModelFieldCopier,
            ICarBodyTypeFieldCopier carBodyTypeFieldCopier,
            ICarOptionManager carOptionManager)
        {
            _carModelFieldCopier = carModelFieldCopier;
            _carBodyTypeFieldCopier = carBodyTypeFieldCopier;
            _carOptionManager = carOptionManager;
        }

        public CarItemViewModel CopyFields(CarItem from, CarItemViewModel to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Id = from.Id;
            to.BodyTypeId = from.BodyTypeId;
            to.ModelId = from.ModelId;
            to.Description = from.Description;
            to.CarModel = _carModelFieldCopier.CopyFields(from.CarModel, to.CarModel);
            to.CarBodyType = _carBodyTypeFieldCopier.CopyFields(from.CarBodyType, to.CarBodyType);
            to.ManufacturerId = from.CarModel.ManufacturerId;
            to.CountryId = from.CarModel.Manufacturer.CountryId;

            to.SelectedCarOptions = new string[from.CarOption.Count];
            var arrayCo = new CarOption[from.CarOption.Count];
            from.CarOption.CopyTo(arrayCo, 0);

            for (var i =0; i < from.CarOption.Count;i++)
            {
                to.SelectedCarOptions[i] = arrayCo[i].Id.ToString();
            }
            return to;
        }

        public CarItem CopyFields(CarItemViewModel from, CarItem to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.BodyTypeId = from.BodyTypeId;
            to.ModelId = from.ModelId;
            to.Description = from.Description;

            to.CarOption.Clear();
            if (from.SelectedCarOptions == null) return to;
            foreach(var s in @from.SelectedCarOptions)
            {
                int id;
                if (int.TryParse(s, out id))
                {
                    to.CarOption.Add(_carOptionManager.GetById(id));
                }
            }
            return to;
        }
    }
}
