using Autofac;
using AutoSiteProject.Bl.FieldCopiers;
using AutoSiteProject.Bl.Managers;
using AutoSiteProject.Dal.Entities;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.Bl.Interfaces.FieldCopiers;
using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

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
            builder.RegisterType<CarImageRepository>().As<IGenericRepository<CarImages>>();
            builder.RegisterType<CarItemRepository>().As<ICarItemRpository>();
            builder.RegisterType<CarModelRepository>().As<IGenericRepository<CarModel>>();
            builder.RegisterType<ManufacturerRepository>().As<IGenericRepository<Manufacturer>>();
            builder.RegisterType<CarBodyTypeRepository>().As<IGenericRepository<CarBodyType>>();
            builder.RegisterType<FuelTypeRepository>().As<IGenericRepository<FuelType>>();
            builder.RegisterType<TransmitionTypeRepository>().As<IGenericRepository<TransmitionType>>();
        }

        private void RegisterBlManagers(ContainerBuilder builder)
        {
            builder.RegisterType<CountryManager>().As<ICountryManager>();
            builder.RegisterType<CarModelManager>().As<ICarModelManager>();
            builder.RegisterType<ManufacturerManager>().As<IManufacturerManager>();
            builder.RegisterType<CarBodyTypeManager>().As<ICarBodyTypeManager>();
            builder.RegisterType<CarOptionManager>().As<ICarOptionManager>();
            builder.RegisterType<CarItemManager>().As<ICarItemManager>();
            builder.RegisterType<CarImageManager>().As<ICarImageManager>();
            builder.RegisterType<FuelTypeManager>().As<IFuelTypeManager>();
            builder.RegisterType<TransmitionTypeManager>().As<ITransmitionTypeManager>();
            builder.RegisterType<AppLogger>().As<IAppLogger>().SingleInstance();
            
        }
        private void RegisterBlFieldCopiers(ContainerBuilder builder)
        {
            builder.RegisterType<CountryFieldCopier>().As<ICountryFieldCopier>();
            builder.RegisterType<CarModelFieldCopier>().As<ICarModelFieldCopier>();
            builder.RegisterType<ManufacturerFieldCopier>().As<IManufacturerFieldCopier>();
            builder.RegisterType<CarBodyTypeFieldCopier>().As<ICarBodyTypeFieldCopier>();
            builder.RegisterType<CarItemFieldCopier>().As<ICarItemFieldCopier>();
            builder.RegisterType<CarOptionFieldCopier>().As<ICarOptionFieldCopier>();
            builder.RegisterType<RoleFieldCopier>().As<IRoleFieldCopier>();
            builder.RegisterType<UserFieldCopier>().As<IUserFieldCopier>();
            builder.RegisterType<CarImageFieldCopier>().As<ICarImageFieldCopier>();
            builder.RegisterType<FuelTypeFieldCopier>().As<IFuelTypeFieldCopier>();
            builder.RegisterType<TransmitionTypeFieldCopier>().As<ITransmitionTypeFieldCopier>();
        }
    }
}
