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

namespace AutoSiteProject.UI.Controllers
{
    [RequireHttps]
    public class UserController : BaseController
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private IUserFieldCopier _userFieldCopier;
        private IRoleFieldCopier _roleFieldCopier;
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
        public ActionResult List()
        {
            var usersViewModels = new List<UserViewModel>();
            var dbUsers = UserManager.Users.ToList();
            foreach (var u in dbUsers)
            {
                usersViewModels.Add(_userFieldCopier.CopyFields(u, new UserViewModel()));
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
                await _userManager.UpdateAsync(dbUser);
                return RedirectToAction("List");
            }
            return View();
        }
    }
}