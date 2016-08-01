using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSiteProject.Models.ViewModels
{
    public class TransmitionTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Transmition type name")]
        [Remote("CheckTransmitionTypeNameForExist", "Validation", AdditionalFields = "Id", ErrorMessage = "Car transmition type with same name already exist.")]
        public string Name { get; set; }
    }
}
