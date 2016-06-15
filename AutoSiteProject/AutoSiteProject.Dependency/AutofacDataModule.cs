using Autofac;
using AutoSiteProject.Dal.Entities;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Dependency
{
    public class AutofacDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GenericRepository<AutoSiteProjectDBEntities,Country>>().As<IGenericRepository<Country>>().SingleInstance();
            builder.RegisterType<GenericRepository<AutoSiteProjectDBEntities, CarModel>>().As<IGenericRepository<Country>>().SingleInstance();
            builder.RegisterType<GenericRepository<AutoSiteProjectDBEntities, Manufacturer>>().As<IGenericRepository<Country>>().SingleInstance();
            builder.RegisterType<GenericRepository<AutoSiteProjectDBEntities, CarBodyType>>().As<IGenericRepository<Country>>().SingleInstance();
            base.Load(builder);
        }
    }
}
