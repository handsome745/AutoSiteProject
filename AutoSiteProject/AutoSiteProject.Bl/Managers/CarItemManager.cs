using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Bl.Managers
{
    public class CarItemManager : RepositoryManager<CarItem>, ICarItemManager
    {
        public CarItemManager(IGenericRepository<CarItem> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {

        }

    }
}
