using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSiteProject.Models.ViewModels
{
    public class TransmitionTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Transmition type name")]
        public string Name { get; set; }
    }
}
