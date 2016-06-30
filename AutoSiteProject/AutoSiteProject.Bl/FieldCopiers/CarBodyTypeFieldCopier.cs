using System;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class CarBodyTypeFieldCopier : ICarBodyTypeFieldCopier
    {
        public CarBodyTypeViewModel CopyFields(CarBodyType from, CarBodyTypeViewModel to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public CarBodyType CopyFields(CarBodyTypeViewModel from, CarBodyType to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Name = from.Name;
            return to;
        }
    }
}
