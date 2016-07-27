using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.Dal.Interfaces;

namespace AutoSiteProject.Dal.Entities
{
    public class FuelTypeRepository : GenericRepository<FuelType>
    {
        public FuelTypeRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {

        }
    }
}
