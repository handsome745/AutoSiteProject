using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System.Collections.Generic;

namespace AutoSiteProject.Models.Bl.Interfaces
{
    public interface ICarItemManager : IRepositoryManager<CarItem>
    {
        List<CarAggregateViewModel> GetCarAggregateViewModel(Expression<Func<FitleXXr, bool>> filter);
    }
}
