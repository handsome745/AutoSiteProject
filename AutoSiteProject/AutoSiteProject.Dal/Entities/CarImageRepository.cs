using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Dal.Entities
{
    public class CarImageRepository : GenericRepository<CarImages>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarImageRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
