using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Bl.Managers
{
    public class CarModelManager : BaseManager<CarModel>, ICarModelManager
    {
        public CarModelManager(IGenericRepository<CarModel> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            
        }
       
    }
}
