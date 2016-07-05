using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.Dal.Interfaces;
using System.Linq;
using AutoSiteProject.Models.ViewModels;
using System;
using System.Linq.Expressions;
using LinqKit;

namespace AutoSiteProject.Dal.Entities
{
    public class CarItemRepository : GenericRepository<CarItem>, ICarItemRpository
    {
        private IUnitOfWork _unitOfWork;
        public CarItemRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<CarAggregateViewModel> GetCarsAggregateViewModel(Expression<Func<CarAggregateViewModel, bool>> predicate)
        {
            var result =
                from ci in _unitOfWork.Set<CarItem>()
                join cm in _unitOfWork.Set<CarModel>() on ci.ModelId equals cm.Id
                join cman in _unitOfWork.Set<Manufacturer>() on cm.ManufacturerId equals cman.Id
                join cc in _unitOfWork.Set<Country>() on cman.CountryId equals cc.Id
                join cbt in _unitOfWork.Set<CarBodyType>() on ci.BodyTypeId equals cbt.Id
                select new CarAggregateViewModel
                {
                    CarId = ci.Id,
                    BodyTypeId = cbt.Id,
                    BodyType = cbt.Name,
                    CountryId = cc.Id,
                    Country = cc.Name,
                    ManufacturerId = cman.Id,
                    Manufacturer = cman.Name,
                    ModelId = cm.Id,
                    Model = cm.Name,
                    Description = ci.Description,
                    Options = ci.CarOption.Select(co => co.Id.ToString()).ToList(),
                    OptionsNames = ci.CarOption.Select(co => co.Name).ToList()
                };
            return result.AsExpandable().Where(predicate);
        }
    }
}
