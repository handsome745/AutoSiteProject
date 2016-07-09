using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoSiteProject.Models.ViewModels
{
    public sealed class CarItemViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Сar manufacturer country")]
        public int? CountryId { get; set; }
        public string Country { get; set; }

        [Required]
        [DisplayName("Сar manufacturer")]
        public int? ManufacturerId { get; set; }
        public string Manufacturer { get; set; }

        [Required]
        [DisplayName("Сar model")]
        public int? ModelId { get; set; }
        public string CarModel { get; set; }

        [Required]
        [DisplayName("Сar body type")]
        public int? BodyTypeId { get; set; }
        public string CarBodyType { get; set; }


        public List<CarOptionViewModel> AvalibleCarOptions { get; set; }
        [DisplayName("Car options")]
        public string[] SelectedCarOptions { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public CarItemViewModel()
        {
            AvalibleCarOptions = new List<CarOptionViewModel>();
        }
    }
}
