using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Bl.Managers
{
    public class CarOptionManager : BaseManager<CarOption>, ICarOptionManager
    {
        public CarOptionManager(IGenericRepository<CarOption> repository, IUnitOfWork unitOfWork)
            : base(repository,unitOfWork)
        {
            
        }
    }
}
