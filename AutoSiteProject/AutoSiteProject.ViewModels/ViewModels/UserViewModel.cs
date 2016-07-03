using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoSiteProject.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string Email { get; set; }
        public List<RoleViewModel> AvalibleRoles { get; set; }
        public string[] SelectedRoles { get; set; }
        public UserViewModel()
        {
            AvalibleRoles = new List<RoleViewModel>();
            SelectedRoles = new string[0];
        }
    }
}
