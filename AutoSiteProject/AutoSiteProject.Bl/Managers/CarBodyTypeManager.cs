using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Bl.Managers
{
    public class CarBodyTypeManager : RepositoryManager<CarBodyType>, ICarBodyTypeManager
    {
        public CarBodyTypeManager(IGenericRepository<CarBodyType> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            
        }
       
    }
}
