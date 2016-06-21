using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoSiteProject.Models.ViewModels
{
    public class CarModelViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Manufacturer")]
        public Nullable<int> ManufacturerId { get; set; }

        public virtual ManufacturerViewModel Manufacturer { get; set; }
    }
}
