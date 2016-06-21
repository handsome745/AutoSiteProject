using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.UI.Utils
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(RegMaps);
        }

        private static void RegMaps(AutoMapper.IMapperConfiguration cfg)
        {
            cfg.CreateMap<Country, CountryViewModel>();
            cfg.CreateMap<CountryViewModel, Country>();

            cfg.CreateMap<CarBodyType, CarBodyTypeViewModel>();
            cfg.CreateMap<CarBodyTypeViewModel, CarBodyType>();

            cfg.CreateMap<CarModel, CarModelViewModel>();
            cfg.CreateMap<CarModelViewModel, CarModel>();

            cfg.CreateMap<Manufacturer, ManufacturerViewModel>();
            cfg.CreateMap<ManufacturerViewModel, Manufacturer>();

            cfg.CreateMap<CarOption, CarOptionViewModel>();
            cfg.CreateMap<CarOptionViewModel, CarOption>();

            cfg.CreateMap<CarItem, CarItemViewModel>();
            cfg.CreateMap<CarItemViewModel, CarItem>();

        }
        
    }
}