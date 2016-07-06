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

        public CountryViewModel Country { get; set; }
        [Required]
        [DisplayName("Сar manufacturer")]
        public int? ManufacturerId { get; set; }

        public ManufacturerViewModel Manufacturer { get; set; }

        [Required]
        [DisplayName("Сar model")]
        public int? ModelId { get; set; }

        public CarModelViewModel CarModel { get; set; }

        [Required]
        [DisplayName("Сar body type")]
        public int? BodyTypeId { get; set; }

        public CarBodyTypeViewModel CarBodyType { get; set; }



        public List<CarOptionViewModel> AvalibleCarOptions { get; set; }
        [DisplayName("Car options")]
        public string[] SelectedCarOptions { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public CarItemViewModel()
        {
            Country = new CountryViewModel();
            Manufacturer = new ManufacturerViewModel();
            CarModel = new CarModelViewModel();
            CarBodyType = new CarBodyTypeViewModel();
            AvalibleCarOptions = new List<CarOptionViewModel>();
        }
    }
}
