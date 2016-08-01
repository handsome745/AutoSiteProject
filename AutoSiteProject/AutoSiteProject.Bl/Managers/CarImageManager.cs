using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.Managers
{
    public class CarImageManager : BaseManager<CarImages>, ICarImageManager
    {
        public CarImageManager(IGenericRepository<CarImages> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {

        }
    }
}