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

        public CarItemFieldCopier(ICarOptionManager carOptionManager)
        {
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
            to.CarBodyType =  from.CarBodyType?.Name;
            if (@from.CarModel != null)
            {
                to.CarModel = from.CarModel.Name;
                to.ManufacturerId = @from.CarModel.ManufacturerId;
                to.Manufacturer = @from.CarModel.Manufacturer?.Name;
                to.CountryId = @from.CarModel.Manufacturer?.CountryId;
                to.Country = @from.CarModel.Manufacturer?.Country?.Name;
            }
            to.SelectedCarOptions = new string[from.CarOption.Count];
            var arrayCo = new CarOption[from.CarOption.Count];
            from.CarOption.CopyTo(arrayCo, 0);
            for (var i = 0; i < from.CarOption.Count; i++)
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
            foreach (var s in @from.SelectedCarOptions)
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
