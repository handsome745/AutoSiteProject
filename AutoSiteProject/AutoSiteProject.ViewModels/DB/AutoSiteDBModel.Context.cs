﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AutoSiteProjectDBEntities : DbContext
    {
        public AutoSiteProjectDBEntities()
            : base("name=AutoSiteProjectDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CarBodyType> CarBodyType { get; set; }
        public virtual DbSet<CarModel> CarModel { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<CarItem> CarItem { get; set; }
        public virtual DbSet<CarOption> CarOption { get; set; }
    }
}
