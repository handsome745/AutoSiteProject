using System.Collections.Generic;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Models.Bl.Interfaces.Managers
{
    public interface ICarItemManager : IRepositoryManager<CarItem>
    {
        List<CarAggregateViewModel> GetCarsAggregateViewModel(CarAggregateFilterViewModel filter);
        //Expression<Func<CarAggregateFilterViewModel, bool>> filter);
    }
}
