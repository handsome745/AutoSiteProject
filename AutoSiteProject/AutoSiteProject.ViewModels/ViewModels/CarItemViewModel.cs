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
            CarOption = new List<CarOptionViewModel>();
        }
        public int Id { get; set; }
        [DisplayName("Сar manufacturer country")]
        public int? CountryId { get; set; }

        public virtual CountryViewModel Country { get; set; }

        [DisplayName("Сar manufacturer")]
        public int? ManufacturerId { get; set; }

        public virtual ManufacturerViewModel Manufacturer { get; set; }

        [Required]
        [DisplayName("Сar model")]
        public int? ModelId { get; set; }

        public virtual CarModelViewModel CarModel { get; set; }

        [Required]
        [DisplayName("Сar body type")]
        public int? BodyTypeId { get; set; }

        public virtual CarBodyTypeViewModel CarBodyType { get; set; }

        [DisplayName("Сar options")]
        public List<CarOptionViewModel> CarOption { get; set; }
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
