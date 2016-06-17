using System.Linq;
using AutoMapper;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.Managers
{
    public class CarModelManager : RepositoryManager<CarModel, CarModelViewModel>, ICarModelManager
    {
       
    }
}
