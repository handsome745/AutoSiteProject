using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Dal.Entities
{
    public class TransmitionTypeRepository : GenericRepository<TransmitionType>
    {
        public TransmitionTypeRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {

        }
    }
}
