//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoSiteProject.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Manufacturer : WithId
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manufacturer()
        {
            this.CarModel = new HashSet<CarModel>();
        }
    
        //public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> CountryId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarModel> CarModel { get; set; }
        public virtual Country Country { get; set; }
    }
}
