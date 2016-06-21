using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSiteProject.Models.ViewModels
{
    public class CarItemViewModel
    {
        public CarItemViewModel()
        {
            CarOptions = new List<int>();
        }
        public int Id { get; set; }
        [DisplayName("Select car manufacturer country:")]
        public int? CountryId { get; set; }
        [DisplayName("Select car manufacturer:")]
        public int? ManufacturerId { get; set; }
        [DisplayName("Select car model:")]
        public int? ModelId { get; set; }
        [DisplayName("Select car body type:")]
        public int? CarBodyTypeId { get; set; }
        [DisplayName("Select car options:")]
        public List<int> CarOptions { get; set; }
        [DisplayName("Description:")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
