using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class CarModelFieldCopier : ICarModelFieldCopier
    {
        private IManufacturerFieldCopier _manufacturerFieldCopier;

        public CarModelFieldCopier(IManufacturerFieldCopier manufacturerFieldCopier)
        {
            _manufacturerFieldCopier = manufacturerFieldCopier;
        }

        public CarModelViewModel CopyFields(CarModel from, CarModelViewModel to)
        {
            if (to == null) to = new CarModelViewModel();
            to.Id = from.Id;
            to.Name = from.Name;
            to.ManufacturerId = from.ManufacturerId;
            to.Manufacturer = _manufacturerFieldCopier.CopyFields(from.Manufacturer, to.Manufacturer);
            return to;
        }

        public CarModel CopyFields(CarModelViewModel from, CarModel to)
        {
            to.Name = from.Name;
            to.ManufacturerId = from.ManufacturerId;
            return to;
        }
    }
}
