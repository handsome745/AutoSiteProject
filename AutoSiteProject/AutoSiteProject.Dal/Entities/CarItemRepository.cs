using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.Dal.Interfaces;

namespace AutoSiteProject.Dal.Entities
{
    public class CarItemRepository: GenericRepository<CarItem>
    {
        public CarItemRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            
        }
    }
}
