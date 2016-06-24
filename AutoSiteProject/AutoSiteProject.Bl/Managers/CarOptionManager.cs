using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Bl.Managers
{
    public class CarOptionManager : RepositoryManager<CarOption>, ICarOptionManager
    {
        public CarOptionManager(IGenericRepository<CarOption> repository, IUnitOfWork unitOfWork)
            : base(repository,unitOfWork)
        {
            
        }
    }
}
