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
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public Country CopyFields(CountryViewModel from, Country to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Name = from.Name;
            return to;
        }
    }
}
