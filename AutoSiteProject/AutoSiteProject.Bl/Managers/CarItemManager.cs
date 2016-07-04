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
        private readonly ICarItemRpository _carRepository;
        public CarItemManager(ICarItemRpository repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            _carRepository = repository;
        }
        public List<CarAggregateViewModel> GetCarsAggregateViewModel(CarAggregateFilterViewModel filter)
        {
            List<CarAggregateViewModel> result = new List<CarAggregateViewModel>();
            var predicateBuilder = PredicateBuilder.True<CarAggregateViewModel>();
            if (filter.BodyTypeId != null)
                predicateBuilder = predicateBuilder.And(c => c.BodyTypeId == filter.BodyTypeId);
            if (filter.ModelId != null)
                predicateBuilder = predicateBuilder.And(c => c.ModelId == filter.ModelId);
            if (filter.ManufacturerId != null)
                predicateBuilder = predicateBuilder.And(c => c.ManufacturerId == filter.ManufacturerId);
            if (filter.CountryId != null)
                predicateBuilder = predicateBuilder.And(c => c.CountryId == filter.CountryId);
            if (filter.OptionsIds.Count > 0)
                predicateBuilder = predicateBuilder.And(c => c.Options.Intersect(filter.OptionsIds).Any());
            result = _carRepository.GetCarsAggregateViewModel(predicateBuilder).ToList();
            return result;
        }
    }
}
