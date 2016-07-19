using System.Collections.Generic;
using System.ComponentModel;
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
        public List<string> Options { get; set; }
        [DisplayName("Car options")]
        public List<string> OptionsNames { get; set; }
        public string OptionsNamesString => string.Join(", ", OptionsNames);
        [DisplayName("Description")]
        public string Description { get; set; }

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
        [DisplayName("Car options")]
        public List<string> OptionsIds { get; set; }
        public List<CarOptionViewModel> AvalibleCarOptions { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}
