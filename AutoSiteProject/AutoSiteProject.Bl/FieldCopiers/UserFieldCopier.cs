using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using System;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using AutoSiteProject.Bl.IdentityClasses;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class UserFieldCopier : IUserFieldCopier
    {
        private readonly ApplicationRoleManager _roleManager;
        private readonly ApplicationUserManager _userManager;

        public UserFieldCopier()
        {
            _userManager = UserManager;
            _roleManager = RoleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
            }
        }
        public UserViewModel CopyFields(ApplicationUser from, UserViewModel to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Id = from.Id;
            to.Name = from.UserName;
            to.Email = from.Email;
            if (@from.Roles == null) return to;
            to.SelectedRoles = new string[@from.Roles.Count];
            var arrayAr = new IdentityUserRole[@from.Roles.Count];
            @from.Roles.CopyTo(arrayAr, 0);
            for (var i = 0; i < @from.Roles.Count; i++)
            {
                to.SelectedRoles[i] = arrayAr[i].RoleId;
            }
            return to;
        }
        public ApplicationUser CopyFields(UserViewModel from, ApplicationUser to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.UserName = from.Name;
            to.Email = from.Email;
            return to;
        }
    }
}
