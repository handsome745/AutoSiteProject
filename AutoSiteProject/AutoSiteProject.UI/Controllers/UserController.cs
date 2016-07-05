using AutoSiteProject.Bl.IdentityClasses;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AutoSiteProject.UI.Controllers
{
    [RequireHttps]
    [Authorize(Roles = "Admin")]
    public class UserController : BaseController
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private readonly IUserFieldCopier _userFieldCopier;
        private readonly IRoleFieldCopier _roleFieldCopier;
        public UserController(IUserFieldCopier userFieldCopier, IRoleFieldCopier roleFieldCopier)
        {
            _userFieldCopier = userFieldCopier;
            _roleFieldCopier = roleFieldCopier;
        }
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
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
                return _userManager ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public async Task<ActionResult> List()
        {
            var usersViewModels = new List<UserViewModel>();
            var dbUsers = UserManager.Users.ToList();
            foreach (var u in dbUsers)
            {
                var q = _userFieldCopier.CopyFields(u, new UserViewModel());
                for (int i = 0; i < q.SelectedRoles.Count(); i++)
                {
                    q.SelectedRoles[i] = (await RoleManager.FindByIdAsync(q.SelectedRoles[i])).Name;
                }
                usersViewModels.Add(q);
            }
            return View(usersViewModels);
        }
        public ActionResult Edit(string id)
        {
            var dbUser = UserManager.Users.Where(u => u.Id == id).FirstOrDefault();
            if (dbUser == null) throw new ObjectNotFoundException();
            var userViewModel = _userFieldCopier.CopyFields(dbUser, new UserViewModel());
            var dbRoles = RoleManager.Roles.ToList();
            foreach (var item in dbRoles)
            {
                userViewModel.AvalibleRoles.Add(_roleFieldCopier.CopyFields(item, new RoleViewModel()));
            }
            return View(userViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var dbUser = UserManager.Users.Where(u => u.Id == userViewModel.Id).FirstOrDefault();
                if (dbUser == null) throw new ObjectNotFoundException();
                dbUser = _userFieldCopier.CopyFields(userViewModel, dbUser);
                await UserManager.UpdateAsync(dbUser);

                var userRolesToDelete = UserManager.GetRoles(dbUser.Id);

                foreach (var roleId in userViewModel.SelectedRoles)
                {
                    var role = RoleManager.FindById(roleId);
                    if (userRolesToDelete.Contains(role.Name))
                        userRolesToDelete.RemoveAt(userRolesToDelete.IndexOf(role.Name));
                    UserManager.AddToRole(dbUser.Id, role.Name);
                }
                foreach (var roleName in userRolesToDelete)
                {
                    UserManager.RemoveFromRole(dbUser.Id, roleName);
                }

                return RedirectToAction("List");
            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            UserManager.Delete(UserManager.FindById(id));
            return RedirectToAction("List");
        }
    }
}