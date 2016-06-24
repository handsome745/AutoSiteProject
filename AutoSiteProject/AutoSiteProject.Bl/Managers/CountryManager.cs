using System.Linq;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Bl.Managers
{
    public class CountryManager : RepositoryManager<Country>, ICountryManager
    {
        public CountryManager(IGenericRepository<Country> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            
        }
    }
}
