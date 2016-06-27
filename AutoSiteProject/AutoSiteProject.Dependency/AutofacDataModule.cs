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
            builder.RegisterType<UnitOfWork>()
               .As<IUnitOfWork>()
               .InstancePerLifetimeScope();

            builder.RegisterType<AutoSiteProjectDBEntities>().AsSelf();

            builder.RegisterType<CountryRepository>().As<IGenericRepository<Country>>();
            builder.RegisterType<CarOptionRepository>().As<IGenericRepository<CarOption>>();
            builder.RegisterType<CarItemRepository>().As<IGenericRepository<CarItem>>();
            builder.RegisterType<CarModelRepository>().As<IGenericRepository<CarModel>>();
            builder.RegisterType<ManufacturerRepository>().As<IGenericRepository<Manufacturer>>();
            builder.RegisterType<CarBodyTypeRepository>().As<IGenericRepository<CarBodyType>>();
        }

        private void RegisterBlManagers(ContainerBuilder builder)
        {
            builder.RegisterType<CountryManager>().As<ICountryManager>();
            builder.RegisterType<CarModelManager>().As<ICarModelManager>();
            builder.RegisterType<ManufacturerManager>().As<IManufacturerManager>();
            builder.RegisterType<CarBodyTypeManager>().As<ICarBodyTypeManager>();
            builder.RegisterType<CarOptionManager>().As<ICarOptionManager>();
            builder.RegisterType<CarItemManager>().As<ICarItemManager>();
            builder.RegisterType<AppLogger>().As<IAppLogger>().SingleInstance();
            //.WithProperty("Repository", new CarItemRepository()).InstancePerRequest();
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
