using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Bl.Managers
{
    public class ManufacturerManager : RepositoryManager<Manufacturer>, IManufacturerManager
    {
        public ManufacturerManager(IGenericRepository<Manufacturer> repository, IUnitOfWork unitOfWork)
            : base(repository,unitOfWork)
        {
            
        }
       
    }
}
