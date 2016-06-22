using System;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class CountryFieldCopier : ICountryFieldCopier
    {
        public CountryViewModel CopyFields(Country from, CountryViewModel to)
        {
            if (to == null) to = new CountryViewModel();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public Country CopyFields(CountryViewModel from, Country to)
        {
            to.Name = from.Name;
            return to;
        }
    }
}
