using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Dal.Entities
{
    class TransmitionTypeRepository : GenericRepository<TransmitionType>
    {
        public TransmitionTypeRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {

        }
    }
}
