using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoSiteProject.Models.ViewModels
{
    public class FuelTypeViewModel
    {
        
        public int Id { get; set; }
        [Required]
        [DisplayName("Fuel type name")]
        public string Name { get; set; }
    }
}
