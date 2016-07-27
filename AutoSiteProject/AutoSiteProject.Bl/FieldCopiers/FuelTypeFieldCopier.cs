using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class FuelTypeFieldCopier : IFuelTypeFieldCopier
    {
        public FuelTypeViewModel CopyFields(FuelType from, FuelTypeViewModel to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public FuelType CopyFields(FuelTypeViewModel from, FuelType to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            
            to.Name = from.Name;
            return to;
        }
    }
}
