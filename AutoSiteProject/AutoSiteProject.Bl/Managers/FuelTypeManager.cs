using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Bl.Managers
{
    public class FuelTypeManager : BaseManager<FuelType>, IFuelTypeManager
    {
        public FuelTypeManager(IGenericRepository<FuelType> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {

        }
    }
}
