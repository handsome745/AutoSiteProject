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
            builder.RegisterType<CountryRepository>().As<IGenericRepository<Country>>().InstancePerRequest();
            builder.RegisterType<CarOptionRepository>().As<IGenericRepository<CarOption>>().InstancePerRequest();
            builder.RegisterType<CarItemRepository>().As<IGenericRepository<CarItem>>().InstancePerRequest();
            builder.RegisterType<CarModelRepository>().As<IGenericRepository<CarModel>>().InstancePerRequest();
            builder.RegisterType<ManufacturerRepository>().As<IGenericRepository<Manufacturer>>().InstancePerRequest();
            builder.RegisterType<CarBodyTypeRepository>().As<IGenericRepository<CarBodyType>>().InstancePerRequest();
        }

        private void RegisterBlManagers(ContainerBuilder builder)
        {
            builder.RegisterType<CountryManager>().As<ICountryManager>().WithProperty("Repository", new CountryRepository()).InstancePerRequest();
            builder.RegisterType<CarModelManager>().As<ICarModelManager>().WithProperty("Repository", new CarModelRepository()).InstancePerRequest();
            builder.RegisterType<ManufacturerManager>().As<IManufacturerManager>().WithProperty("Repository", new ManufacturerRepository()).InstancePerRequest();
            builder.RegisterType<CarBodyTypeManager>().As<ICarBodyTypeManager>().WithProperty("Repository", new CarBodyTypeRepository()).InstancePerRequest();
            builder.RegisterType<CarOptionManager>().As<ICarOptionManager>().WithProperty("Repository", new CarOptionRepository()).InstancePerRequest();
            builder.RegisterType<CarItemManager>().As<ICarItemManager>().WithProperty("Repository", new CarItemRepository()).InstancePerRequest();
        }
        private void RegisterBlFieldCopiers(ContainerBuilder builder)
        {
            builder.RegisterType<CountryFieldCopier>().As<ICountryFieldCopier>().InstancePerRequest();
            builder.RegisterType<CarModelFieldCopier>().As<ICarModelFieldCopier>().InstancePerRequest();
            builder.RegisterType<ManufacturerFieldCopier>().As<IManufacturerFieldCopier>().InstancePerRequest();
            builder.RegisterType<CarBodyTypeFieldCopier>().As<ICarBodyTypeFieldCopier>().InstancePerRequest();
            builder.RegisterType<CarItemFieldCopier>().As<ICarItemFieldCopier>().InstancePerRequest();
            builder.RegisterType<CarOptionFieldCopier>().As<ICarOptionFieldCopier>().InstancePerRequest();
        }
    }
}
