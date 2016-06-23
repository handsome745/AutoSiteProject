using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutoSiteProject.Models.ViewModels
{
    public class ManufacturerViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        [Remote("ChecManufacturerNameForExist", "Validation", ErrorMessage = "Manufacturer with same name already exist.")]
        public string Name { get; set; }
        [DisplayName("Country")]
        public Nullable<int> CountryId { get; set; }
        
        public virtual CountryViewModel Country { get; set; }
    }
}
