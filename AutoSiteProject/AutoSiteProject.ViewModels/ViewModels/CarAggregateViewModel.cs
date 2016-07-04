using System.Collections.Generic;

namespace AutoSiteProject.Models.ViewModels
{
    public class CarAggregateViewModel
    {
        public CarAggregateViewModel()
        {
            Options = new List<string>();
            OptionsNames = new List<string>();
        }

        public int CarId { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public int ManufacturerId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int ModelId { get; set; }
        public string BodyType { get; set; }
        public int BodyTypeId { get; set; }
        public List<string> Options { get; set; }
        public List<string> OptionsNames { get; set; }
        public string Description { get; set; }
    }

    public class CarAggregateFilterViewModel
    {
        public CarAggregateFilterViewModel()
        {
            OptionsIds = new List<string>();
            AvalibleCarOptions = new List<CarOptionViewModel>();
        }
        public int? CountryId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? ModelId { get; set; }
        public int? BodyTypeId { get; set; }
        public List<string> OptionsIds { get; set; }
        public List<CarOptionViewModel> AvalibleCarOptions { get; set; }
    }
}
