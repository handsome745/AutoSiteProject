using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using System;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using AutoSiteProject.Bl.IdentityClasses;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AutoSiteProject.Bl.FieldCopiers
{
    public class UserFieldCopier : IUserFieldCopier
    {
        private IRoleFieldCopier _roleFieldCopier;
        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;
        public UserFieldCopier(IRoleFieldCopier roleFieldCopier)
        {
            _roleFieldCopier = roleFieldCopier;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public UserViewModel CopyFields(ApplicationUser from, UserViewModel to)
        {
            if (to == null) throw new NullReferenceException();
            if (from == null) throw new NullReferenceException();
            to.Id = from.Id;
            to.Name = from.UserName;
            to.Email = from.Email;
            if (from.Roles != null)
            {
                to.SelectedRoles = new string[from.Roles.Count];
                IdentityUserRole[] arrayAR = new IdentityUserRole[from.Roles.Count];
                from.Roles.CopyTo(arrayAR, 0);
                for (int i = 0; i < from.Roles.Count; i++)
                {
                    to.SelectedRoles[i] = arrayAR[i].RoleId.ToString();
                }
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
