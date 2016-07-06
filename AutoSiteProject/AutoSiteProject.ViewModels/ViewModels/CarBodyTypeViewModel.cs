using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutoSiteProject.Models.ViewModels
{
    public class CarBodyTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        [Remote("CheckBodyTypeNameForExist", "Validation", AdditionalFields = "Id", ErrorMessage = "Car body type with same name already exist.")]
        public string Name { get; set; }
    }
}
