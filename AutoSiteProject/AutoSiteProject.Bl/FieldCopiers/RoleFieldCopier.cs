using System;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class RoleFieldCopier : IRoleFieldCopier
    {
        public RoleViewModel CopyFields(ApplicationRole from, RoleViewModel to)
        {
            if (from == null) throw new NullReferenceException();
            if (to == null) throw new NullReferenceException();
            to.Id = from.Id;
            to.Name = from.Name;
            to.Description = from.Description;
            return to;
        }

        public ApplicationRole CopyFields(RoleViewModel from, ApplicationRole to)
        {
            if (from == null) throw new NullReferenceException();
            if (to == null) throw new NullReferenceException();
            to.Name = from.Name;
            to.Description = from.Description;
            return to;
        }
    }
}
