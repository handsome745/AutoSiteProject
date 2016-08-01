using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutoSiteProject.Models.ViewModels
{
    public class FuelTypeViewModel
    {
        
        public int Id { get; set; }
        [Required]
        [DisplayName("Fuel type name")]
        [Remote("CheckFuelTypeNameForExist", "Validation", AdditionalFields = "Id", ErrorMessage = "Car transmition type with same name already exist.")]
        public string Name { get; set; }
    }
}
