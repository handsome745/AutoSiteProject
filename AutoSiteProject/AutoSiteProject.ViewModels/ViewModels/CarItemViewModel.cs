using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AutoSiteProject.Models.ViewModels
{
    public sealed class CarItemViewModel
    {
        public CarItemViewModel()
        {
            AvalibleCarOptions = new List<CarOptionViewModel>();
            Images = new List<CarImageViewModel>();
        }

        public int Id { get; set; }
        [Required]
        [DisplayName("Сar manufacturer country")]
        public int? CountryId { get; set; }
        public string Country { get; set; }

        [Required]
        [DisplayName("Сar manufacturer")]
        public int? ManufacturerId { get; set; }
        public string Manufacturer { get; set; }

        [Required]
        [DisplayName("Сar model")]
        public int? ModelId { get; set; }
        public string CarModel { get; set; }

        [Required]
        [DisplayName("Сar body type")]
        public int? BodyTypeId { get; set; }
        public string CarBodyType { get; set; }


        public List<CarOptionViewModel> AvalibleCarOptions { get; set; }
        [DisplayName("Car options")]
        public string[] SelectedCarOptions { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string OwnerId { get; set; }

        [Required]
        [DisplayName("Сar transmition type")]
        public int? TransmitionTypeId { get; set; }
        public string TransmitionType { get; set; }

        [Required]
        [DisplayName("Сar fuel type")]
        public int? FuelTypeId { get; set; }
        public string FuelType { get; set; }

        [DisplayName("Car release year")]
        public int ReleaseYear { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid car engine volume in cm3")]
        [DisplayName("Car engine volume(cm3)")]
        public int Volume { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid price")]
        [DisplayName("Car price")]
        public int Price { get; set; }

        public string LastEditorId { get; set; }
        [DisplayName("Edited by")]
        public string LastEditorName { get; set; }
        [DisplayName("Last edit date")]
        public DateTime EditDate { get; set; }

        public CarItemStatus Status { get; set; }
        public List<CarImageViewModel> Images { get; set; }
    }

    public enum CarItemStatus
    {
        Open= 0,
        Close = 1
    }
}
