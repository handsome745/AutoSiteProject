using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using System;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class CarImageFieldCopier : ICarImageFieldCopier
    {
        public CarImageViewModel CopyFields(CarImages from, CarImageViewModel to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Id = from.Id;
            to.Name = from.Name;
            to.ContentLength = from.ContentLength;
            //to.Data = from.Data;
            to.ContentType = from.ContentType;
            return to;
        }

        public CarImages CopyFields(CarImageViewModel from, CarImages to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Id = from.Id;
            to.Name = from.Name;
            to.ContentLength = from.ContentLength;
            to.Data = from.Data;
            to.ContentType = from.ContentType;
            return to;
        }
    }
}
