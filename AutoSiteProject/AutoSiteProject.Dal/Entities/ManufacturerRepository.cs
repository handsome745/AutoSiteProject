using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Dal.Entities
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>
    {
        public ManufacturerRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
    }
}
