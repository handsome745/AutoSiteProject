using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Dal.Entities
{
    public class CountryRepository : GenericRepository<Country>
    {
        public CountryRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            
        }
    }
}
