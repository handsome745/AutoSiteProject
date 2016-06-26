using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutoSiteProject.Models.ViewModels
{
    public class CarOptionViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        [Remote("ChecCarOptionNameForExist", "Validation", AdditionalFields = "Id", ErrorMessage = "Car option with same name already exist.")]
        public string Name { get; set; }
            
    }
}
