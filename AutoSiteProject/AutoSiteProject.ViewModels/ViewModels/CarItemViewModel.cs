using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DisplayName("Manufacturer country")]
        public int? CountryId { get; set; }
        [DisplayName("Manufacturer country")]
        public string Country { get; set; }

        [Required]
        [DisplayName("Manufacturer")]
        public int? ManufacturerId { get; set; }
        [DisplayName("Manufacturer")]
        public string Manufacturer { get; set; }

        [Required]
        [DisplayName("Model")]
        public int? ModelId { get; set; }
        [DisplayName("Model")]
        public string CarModel { get; set; }

        [Required]
        [DisplayName("Body type")]
        public int? BodyTypeId { get; set; }
        [DisplayName("Body type")]
        public string CarBodyType { get; set; }

        public List<CarOptionViewModel> AvalibleCarOptions { get; set; }

        [DisplayName("Options")]
        public string[] SelectedCarOptions { get; set; }

        [DisplayName("Options")]
        [NotMapped]
        public string OptionsNamesString => SelectedCarOptions != null ? string.Join(", ", SelectedCarOptions) : "";

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string OwnerId { get; set; }

        [Required]
        [DisplayName("Transmition type")]
        public int? TransmitionTypeId { get; set; }
        [DisplayName("Transmition type")]
        public string TransmitionType { get; set; }

        [Required]
        [DisplayName("Fuel type")]
        public int? FuelTypeId { get; set; }
        [DisplayName("Fuel type")]
        public string FuelType { get; set; }

        [DisplayName("Release year")]
        public int ReleaseYear { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid car engine volume in cm3")]
        [DisplayName("Engine volume(cm3)")]
        public int Volume { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid price")]
        [DisplayName("Price ($)")]
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
        Open = 0,
        Closed = 1
    }
}
