using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutoSiteProject.Models.ViewModels
{
    public sealed class ManufacturerViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        [Remote("ChecManufacturerNameForExist", "Validation", AdditionalFields = "Id, CountryId", ErrorMessage = "Manufacturer with same name already exist.")]
        public string Name { get; set; }
        [DisplayName("Country")]
        public int? CountryId { get; set; }

        public string Country { get; set; }
    }
}
