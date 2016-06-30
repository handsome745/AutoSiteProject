using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutoSiteProject.Models.ViewModels
{
    public class CarModelViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        [Remote("CheckCarModelNameForExist", "Validation", AdditionalFields = "Id, ManufacturerId", ErrorMessage = "Car body type with same name already exist.")]
        public string Name { get; set; }
        [DisplayName("Manufacturer")]
        public Nullable<int> ManufacturerId { get; set; }

        public virtual ManufacturerViewModel Manufacturer { get; set; }

        public CarModelViewModel()
        {
            Manufacturer = new ManufacturerViewModel();
        }
    }
}
