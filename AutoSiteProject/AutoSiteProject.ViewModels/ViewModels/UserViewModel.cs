using System.Collections.Generic;

namespace AutoSiteProject.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<RoleViewModel> AvalibleRoles { get; set; }
        public string[] SelectedRoles { get; set; }
        public UserViewModel()
        {
            AvalibleRoles = new List<RoleViewModel>();
        }
    }
}
