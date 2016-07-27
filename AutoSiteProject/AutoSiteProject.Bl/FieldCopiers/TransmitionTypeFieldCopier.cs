using System;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class TransmitionTypeFieldCopier : ITransmitionTypeFieldCopier
    {
        public TransmitionTypeViewModel CopyFields(TransmitionType from, TransmitionTypeViewModel to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public TransmitionType CopyFields(TransmitionTypeViewModel from, TransmitionType to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }
    }
}
