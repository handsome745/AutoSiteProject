using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.Dal.Interfaces;

namespace AutoSiteProject.Dal.Entities
{
    public class CarModelRepository: GenericRepository<CarModel>
    {
        public CarModelRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            
        }
    }
}
