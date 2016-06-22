using Autofac;
using AutoSiteProject.Bl.FieldCopiers;
using AutoSiteProject.Bl.Managers;
using AutoSiteProject.Dal.Entities;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
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
            RegisterBlManagers(builder);
            RegisterBlFieldCopiers(builder);
            base.Load(builder);
        }

        private void RegisterDalTypes(ContainerBuilder builder)
        {
            builder.RegisterType<CountryRepository>().As<IGenericRepository<Country>>().SingleInstance();
            builder.RegisterType<CarOptionRepository>().As<IGenericRepository<CarOption>>().SingleInstance();
            builder.RegisterType<CarItemRepository>().As<IGenericRepository<CarItem>>().SingleInstance();
            builder.RegisterType<CarModelRepository>().As<IGenericRepository<CarModel>>().SingleInstance();
            builder.RegisterType<ManufacturerRepository>().As<IGenericRepository<Manufacturer>>().SingleInstance();
            builder.RegisterType<CarBodyTypeRepository>().As<IGenericRepository<CarBodyType>>().SingleInstance();
        }

        private void RegisterBlManagers(ContainerBuilder builder)
        {
            builder.RegisterType<CountryManager>().As<ICountryManager>().WithProperty("Repository", new CountryRepository());
            builder.RegisterType<CarModelManager>().As<ICarModelManager>().WithProperty("Repository", new CarModelRepository());
            builder.RegisterType<ManufacturerManager>().As<IManufacturerManager>().WithProperty("Repository", new ManufacturerRepository());
            builder.RegisterType<CarBodyTypeManager>().As<ICarBodyTypeManager>().WithProperty("Repository", new CarBodyTypeRepository());
            builder.RegisterType<CarOptionManager>().As<ICarOptionManager>().WithProperty("Repository", new CarOptionRepository());
            builder.RegisterType<CarItemManager>().As<ICarItemManager>().WithProperty("Repository", new CarItemRepository());
        }
        private void RegisterBlFieldCopiers(ContainerBuilder builder)
        {
            builder.RegisterType<CountryFieldCopier>().As<ICountryFieldCopier>().SingleInstance();
            builder.RegisterType<CarModelFieldCopier>().As<ICarModelFieldCopier>().SingleInstance();
            builder.RegisterType<ManufacturerFieldCopier>().As<IManufacturerFieldCopier>().SingleInstance();
            builder.RegisterType<CarBodyTypeFieldCopier>().As<ICarBodyTypeFieldCopier>().SingleInstance();
            builder.RegisterType<CarItemFieldCopier>().As<ICarItemFieldCopier>().SingleInstance();
            builder.RegisterType<CarOptionFieldCopier>().As<ICarOptionFieldCopier>().SingleInstance();
        }
    }
}
