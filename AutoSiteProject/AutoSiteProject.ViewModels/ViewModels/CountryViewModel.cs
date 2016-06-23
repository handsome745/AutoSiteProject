using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutoSiteProject.Models.ViewModels
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        [Remote("CheckCountryNameForExist", "Validation", ErrorMessage = "Country with same name already exist.")]
        public string Name { get; set; }
               
    }
}
