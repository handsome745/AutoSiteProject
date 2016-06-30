using System;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class ManufacturerFieldCopier : IManufacturerFieldCopier
    {
        private ICountryFieldCopier _countryFieldCopier;

        public ManufacturerFieldCopier(ICountryFieldCopier countryFieldCopier)
        {
            _countryFieldCopier = countryFieldCopier;
        }

        public ManufacturerViewModel CopyFields(Manufacturer from, ManufacturerViewModel to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Id = from.Id;
            to.Name = from.Name;
            to.CountryId = from.CountryId;
            _countryFieldCopier.CopyFields(from.Country, to.Country);
            return to;
        }

        public Manufacturer CopyFields(ManufacturerViewModel from, Manufacturer to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Name = from.Name;
            to.CountryId = from.CountryId;
            return to;
        }
    }
}
