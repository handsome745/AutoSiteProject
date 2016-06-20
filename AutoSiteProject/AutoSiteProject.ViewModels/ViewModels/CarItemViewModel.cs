using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSiteProject.Models.ViewModels
{
    public class CarItemViewModel
    {
        public int Id { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Car model")]
        public Nullable<int> ModelId { get; set; }
        [DisplayName("Body type")]
        public Nullable<int> BodyTypeId { get; set; }

        public virtual CarBodyTypeViewModel CarBodyType { get; set; }
        public virtual CarModelViewModel CarModel { get; set; }
    }
}
