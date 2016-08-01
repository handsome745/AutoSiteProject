using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using LinqKit;

namespace AutoSiteProject.Bl.Managers
{
    public class CarItemManager : BaseManager<CarItem>, ICarItemManager
    {
        private readonly ICarItemRpository _carRepository;
        public CarItemManager(ICarItemRpository repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            _carRepository = repository;
        }
        public List<CarAggregateViewModel> GetCarsAggregateViewModel(CarAggregateFilterViewModel filter)
        {
            var predicateBuilder = PredicateBuilder.True<CarAggregateViewModel>();
            if (filter.BodyTypeId != null)
                predicateBuilder = predicateBuilder.And(c => c.BodyTypeId == filter.BodyTypeId);
            if (filter.ModelId != null)
                predicateBuilder = predicateBuilder.And(c => c.ModelId == filter.ModelId);
            if (filter.ManufacturerId != null)
                predicateBuilder = predicateBuilder.And(c => c.ManufacturerId == filter.ManufacturerId);
            if (filter.CountryId != null)
                predicateBuilder = predicateBuilder.And(c => c.CountryId == filter.CountryId);
            if (filter.FuelTypeId != null)
                predicateBuilder = predicateBuilder.And(c => c.FuelTypeId == filter.FuelTypeId);
            if (filter.TransmitionTypeId != null)
                predicateBuilder = predicateBuilder.And(c => c.TransmitionTypeId == filter.TransmitionTypeId);

            predicateBuilder = predicateBuilder.And(c => c.Price >= filter.PriceMin);
            predicateBuilder = predicateBuilder.And(c => c.Price <= filter.PriceMax);
            predicateBuilder = predicateBuilder.And(c => c.Volume >= filter.VolumeMin);
            predicateBuilder = predicateBuilder.And(c => c.Volume <= filter.VolumeMax);
            predicateBuilder = predicateBuilder.And(c => c.ReleaseYear >= filter.ReleaseYearMin);
            predicateBuilder = predicateBuilder.And(c => c.ReleaseYear <= filter.ReleaseYearMax);

            if (!string.IsNullOrEmpty(filter.OwnerId)) predicateBuilder = predicateBuilder.And(c => c.OwnerId == filter.OwnerId);

            if (filter.OptionsIds != null && filter.OptionsIds.Count > 0)
                predicateBuilder = predicateBuilder.And(c => c.Options.Intersect(filter.OptionsIds).Count() >= filter.OptionsIds.Count);
            if (!string.IsNullOrEmpty(filter.Description))
                predicateBuilder = predicateBuilder.And(c => c.Description.Contains(filter.Description));

            if (!string.IsNullOrEmpty(filter.AllFieldsSearch))
            {
                var falsePredicateBuilder = PredicateBuilder.False<CarAggregateViewModel>();
                var lowerCaseAllSearch = filter.AllFieldsSearch.ToLower();
                var searchWords = lowerCaseAllSearch.Split(new char[] { ' ', '.', ',', '?', '!' });
                searchWords = searchWords.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
                var param = Expression.Parameter(typeof(CarAggregateViewModel));
                var entityType = typeof(CarAggregateViewModel);
                var propertyType = typeof(string);
                var fields = entityType.GetFields()
                                    .Where(f => f.FieldType == propertyType)
                                    .Select(f => f.Name);
                var properties = entityType.GetProperties()
                                        .Where(p => p.PropertyType == propertyType)
                                        .Select(p => p.Name);
                var allFieldsNames = fields.Concat(properties);
                foreach (var fieldName in allFieldsNames)
                {
                    foreach (var searchWord in searchWords)
                    {
                        if (fieldName == "OptionsNamesString") continue;
                        if (fieldName.Contains("Id")) continue;
                        var predicateToAdd = Expression.Lambda<Func<CarAggregateViewModel, bool>>(
                            Expression.Call(Expression.PropertyOrField(param, fieldName),
                                            typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                                            Expression.Constant(searchWord)
                                           )
                            , param);

                        falsePredicateBuilder = falsePredicateBuilder.Or(predicateToAdd);
                    }
                }
                predicateBuilder = predicateBuilder.And(falsePredicateBuilder);
            }

            var result = _carRepository.GetCarsAggregateViewModel(predicateBuilder).ToList();
            return result;
        }
    }
}
