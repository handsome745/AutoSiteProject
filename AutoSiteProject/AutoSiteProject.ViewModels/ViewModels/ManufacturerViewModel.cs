using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoSiteProject.Models.ViewModels
{
    public class ManufacturerViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Country")]
        public Nullable<int> CountryId { get; set; }

        public virtual ICollection<CarModelViewModel> CarModel { get; set; }
        public virtual CountryViewModel Country { get; set; }
    }
}
