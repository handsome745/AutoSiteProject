using Autofac;
using AutoSiteProject.Bl.Managers;
using AutoSiteProject.Dal.Entities;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Dependency
{
    public class AutofacDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterDalTypes(builder);
            RegisterBlTypes(builder);
            base.Load(builder);
        }

        private void RegisterDalTypes(ContainerBuilder builder)
        {
            builder.RegisterType<CountryRepository>().As<IGenericRepository<Country>>().SingleInstance();
            builder.RegisterType<CarModelRepository>().As<IGenericRepository<CarModel>>().SingleInstance();
            builder.RegisterType<ManufacturerRepository>().As<IGenericRepository<Manufacturer>>().SingleInstance();
            builder.RegisterType<CarBodyTypeRepository>().As<IGenericRepository<CarBodyType>>().SingleInstance();
        }

        private void RegisterBlTypes(ContainerBuilder builder)
        {
            builder.RegisterType<CountryManager>().As<IRepositoryManager<CountryViewModel>>().WithProperty("Repository", new CountryRepository());
            builder.RegisterType<CarModelManager>().As<IRepositoryManager<CarModelViewModel>>().WithProperty("Repository", new CarModelRepository());
            builder.RegisterType<ManufacturerManager>().As<IRepositoryManager<ManufacturerViewModel>>().WithProperty("Repository", new ManufacturerRepository());
            builder.RegisterType<CarBodyTypeManager>().As<IRepositoryManager<CarBodyTypeViewModel>>().WithProperty("Repository", new CarBodyTypeRepository());
        }
    }
}
