using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.Dal.Interfaces;
using System.Linq;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Dal.Entities
{
    public class CarItemRepository : GenericRepository<CarItem>
    {
        private IUnitOfWork _unitOfWork;
        public CarItemRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public IQueryable<CarAggregateViewModel> GetCarAggregateViewModel(xxx filter)
        //{
        //    var result =
        //        from ci in _unitOfWork.Set<CarItem>()
        //        join cm in _unitOfWork.Set<CarModel>() on ci.ModelId equals cm.Id
        //        select new CarAggregateViewModel
        //        {
        //            CarId = ci.Id,
        //            Manufacturer = ci.CarModel.Manufacturer.D
        //        };

        //    return result.Where(filter);
        //}
    }
}
