using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using AutoSiteProject.Bl.IdentityClasses;

namespace AutoSiteProject.UI.Controllers
{
    [RequireHttps]
    [Authorize(Roles = "Admin")]
    public class RoleController : BaseController
    {
        private readonly ApplicationRoleManager _roleManager;
        private readonly IRoleFieldCopier _roleFieldCopier;
        public RoleController(IRoleFieldCopier roleFieldCopier)
        {
            _roleFieldCopier = roleFieldCopier;
            _roleManager = RoleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
        }



        // GET: Role
        public ActionResult List()
        {
            var dbRoles = RoleManager.Roles.ToList();
            var rolesViewModels = dbRoles.Select(r => _roleFieldCopier.CopyFields(r, new RoleViewModel())).ToList();
            return View(rolesViewModels);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                // Initialize ApplicationRole instead of IdentityRole:
                var role = _roleFieldCopier.CopyFields(roleViewModel, new ApplicationRole());
                var roleresult = await RoleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First());
                    return View();
                }
                return RedirectToAction("List");
            }
            return View();
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null) return HttpNotFound();
            var roleModel = _roleFieldCopier.CopyFields(role, new RoleViewModel());
            return View(roleModel);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = await RoleManager.FindByIdAsync(roleViewModel.Id);
                if (role == null) return HttpNotFound();
                role = _roleFieldCopier.CopyFields(roleViewModel, role);
                await RoleManager.UpdateAsync(role);
                return RedirectToAction("List");
            }
            return View();
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null) return HttpNotFound();
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("List");
        }

    }
}