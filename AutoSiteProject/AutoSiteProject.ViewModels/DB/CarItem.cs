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
    
    public partial class CarItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarItem()
        {
            this.CarOption = new HashSet<CarOption>();
            this.CarImages = new HashSet<CarImages>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<int> ModelId { get; set; }
        public Nullable<int> BodyTypeId { get; set; }
        public string OwnerId { get; set; }
        public Nullable<int> MainImageId { get; set; }
    
        public virtual CarBodyType CarBodyType { get; set; }
        public virtual CarModel CarModel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarOption> CarOption { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarImages> CarImages { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual CarImages CarImages1 { get; set; }
    }
}
