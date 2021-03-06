﻿using System;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class CarOptionFieldCopier : ICarOptionFieldCopier
    {
        public CarOptionViewModel CopyFields(CarOption from, CarOptionViewModel to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public CarOption CopyFields(CarOptionViewModel from, CarOption to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Name = from.Name;
            return to;
        }
    }
}
