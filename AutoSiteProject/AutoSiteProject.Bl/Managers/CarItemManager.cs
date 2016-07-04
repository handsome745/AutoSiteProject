using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using LinqKit;

namespace AutoSiteProject.Bl.Managers
{
    public class CarItemManager : RepositoryManager<CarItem>, ICarItemManager
    {
        private readonly IGenericRepository<CarItem> _carRepository;
        public CarItemManager(IGenericRepository<CarItem> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            _carRepository = repository;
        }
        public List<CarAggregateViewModel> GetCarsAggregateViewModel(CarAggregateFilterViewModel filter)
        {
            List<CarAggregateViewModel> result = new List<CarAggregateViewModel>();
            var predicateBuilder = PredicateBuilder.True<CarItem>();
            if (filter.BodyTypeId != null)
                predicateBuilder = predicateBuilder.And(c => c.BodyTypeId == filter.BodyTypeId);
            if (filter.ModelId != null)
                predicateBuilder = predicateBuilder.And(c => c.ModelId == filter.ModelId);
            if (filter.ManufacturerId != null)
                predicateBuilder = predicateBuilder.And(c => c.CarModel.ManufacturerId == filter.ManufacturerId);
            if (filter.CountryId != null)
                predicateBuilder = predicateBuilder.And(c => c.CarModel.Manufacturer.CountryId == filter.CountryId);
            if (filter.OptionsIds.Count > 0)
                predicateBuilder = predicateBuilder.And(
                    c => c.CarOption.FirstOrDefault(co => filter.OptionsIds.Contains(co.Id.ToString())) != null);

            var dbResult = _carRepository.FindBy(predicateBuilder).ToList();
            foreach (var item in dbResult)
            {
                result.Add(new CarAggregateViewModel
                {
                    Country = item.CarModel.Manufacturer.Country.Name,
                    Manufacturer = item.CarModel.Manufacturer.Name,
                    Model = item.CarModel.Name,
                    BodyType = item.CarBodyType.Name,
                    CarId = item.Id,
                    Description = item.Description,
                    Options = (from i in item.CarOption
                               select i.Name).ToList()
                }
                    );
            }
            return result;
        }
    }
}
