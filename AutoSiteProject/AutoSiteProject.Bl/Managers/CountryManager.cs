using System.Linq;
using AutoMapper;
using AutoSiteProject.Models.ViewModels;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Bl.Managers
{
    public class CountryManager : RepositoryManager<Country , CountryViewModel>
    {
        public override CountryViewModel GetById(int id)
        {
            return  Mapper.Map<Country, CountryViewModel>(Repository.FindBy(c => c.Id == id).FirstOrDefault());
        }
    }
}
