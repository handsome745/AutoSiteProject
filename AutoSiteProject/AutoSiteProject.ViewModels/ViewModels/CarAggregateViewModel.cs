using System.Collections.Generic;

namespace AutoSiteProject.Models.ViewModels
{
    public class CarAggregateViewModel
    {
        public int CarId { get; set; }

        public string Country { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string BodyType { get; set; }
        public List<string> Options { get; set; }
        public string Description { get; set; }
    }

    public class CarAggregateFilterViewModel
    {
        public int CountryId { get; set; }
        public int ManufacturerId { get; set; }
        public int ModelId { get; set; }
        public int BodyTypeId { get; set; }
        public List<string> OptionsIds { get; set; }
    }
}
