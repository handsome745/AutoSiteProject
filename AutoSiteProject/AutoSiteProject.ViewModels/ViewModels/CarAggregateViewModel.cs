using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AutoSiteProject.Models.ViewModels
{
    public class CarAggregateViewModel
    {
        public CarAggregateViewModel()
        {
            Options = new List<string>();
            OptionsNames = new List<string>();
        }
        [DisplayName("Car id")]
        public int CarId { get; set; }
        public int CountryId { get; set; }
        [DisplayName("Country")]
        public string Country { get; set; }
        public int ManufacturerId { get; set; }
        [DisplayName("Manufacturer")]
        public string Manufacturer { get; set; }
        [DisplayName("Car model")]
        public string Model { get; set; }
        public int ModelId { get; set; }
        [DisplayName("Body type")]
        public string BodyType { get; set; }
        public int BodyTypeId { get; set; }
        [DisplayName("Fuel type")]
        public string FuelType { get; set; }
        public int? FuelTypeId { get; set; }
        [DisplayName("Transmition type")]
        public string TransmitionType { get; set; }
        public int? TransmitionTypeId { get; set; }
        public int ReleaseYear { get; set; }
        public int Price { get; set; }
        public int Volume { get; set; }
        public CarItemStatus Status { get; set; }
        public List<string> Options { get; set; }
        [DisplayName("Car options")]
        public List<string> OptionsNames { get; set; }
        [NotMapped]
        public string OptionsNamesString => string.Join(", ", OptionsNames);
        [DisplayName("Description")]
        public string Description { get; set; }
        public string MainImageId { get; set; }
        public string OwnerId { get; set; }
    }

    public class CarAggregateFilterViewModel
    {
        public CarAggregateFilterViewModel()
        {
            OptionsIds = new List<string>();
            AvalibleCarOptions = new List<CarOptionViewModel>();
        }
        [DisplayName("Country")]
        public int? CountryId { get; set; }
        [DisplayName("Manufacturer")]
        public int? ManufacturerId { get; set; }
        [DisplayName("Car model")]
        public int? ModelId { get; set; }
        [DisplayName("Body type")]
        public int? BodyTypeId { get; set; }
        [DisplayName("Fuel type")]
        public int? FuelTypeId { get; set; }
        [DisplayName("Transmition type")]
        public int? TransmitionTypeId { get; set; }
        [DisplayName("Car options")]
        public List<string> OptionsIds { get; set; }
        public List<CarOptionViewModel> AvalibleCarOptions { get; set; }

        [DisplayName("Release year")]
        [Range(0, int.MaxValue, ErrorMessage = "Incorrect min release year")]
        public int ReleaseYearMin { get; set; } = 1990;

        [Range(0, int.MaxValue, ErrorMessage = "Incorrect max release year")]
        public int ReleaseYearMax { get; set; } = DateTime.Now.Year;

        [DisplayName("Price in $")]
        [Range(0, int.MaxValue, ErrorMessage = "Incorrect min price")]
        public int PriceMin { get; set; } = 0;

        [Range(0, int.MaxValue, ErrorMessage = "Incorrect max price")]
        public int PriceMax { get; set; } = 200000;

        [DisplayName("Engine volume(cm3)")]
        [Range(0, int.MaxValue, ErrorMessage = "Incorrect min car engine volume")]
        public int VolumeMin { get; set; } = 0;

        [Range(0, int.MaxValue, ErrorMessage = "Incorrect max car engine volume")]
        public int VolumeMax { get; set; } = 10000;
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("All fields search")]
        public string AllFieldsSearch { get; set; }
        [DisplayName("Owner")]
        public string OwnerId { get; set; }
    }
}
