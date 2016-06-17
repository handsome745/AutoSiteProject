using System.Linq;
using AutoMapper;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.ViewModels;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Bl.Managers
{
    public class CountryManager : RepositoryManager<Country , CountryViewModel>, ICountryManager
    {
       
    }
}
