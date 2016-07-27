using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Bl.Managers
{
    public class TransmitionTypeManager : RepositoryManager<TransmitionType>, ITransmitionTypeManager
    {
        public TransmitionTypeManager(IGenericRepository<TransmitionType> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {

        }
    }
}
