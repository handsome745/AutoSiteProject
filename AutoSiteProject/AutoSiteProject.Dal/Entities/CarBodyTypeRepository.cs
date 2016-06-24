using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.Dal.Interfaces;

namespace AutoSiteProject.Dal.Entities
{
    public class CarBodyTypeRepository : GenericRepository<CarBodyType>, IGenericRepository<CarBodyType>
    {
        public CarBodyTypeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
    }
}
