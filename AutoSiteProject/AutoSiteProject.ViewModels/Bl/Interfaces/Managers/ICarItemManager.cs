using System;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoSiteProject.Models.Bl.Interfaces
{
    public interface ICarItemManager : IRepositoryManager<CarItem>
    {
        List<CarAggregateViewModel> GetCarsAggregateViewModel(CarAggregateFilterViewModel filter);
        //Expression<Func<CarAggregateFilterViewModel, bool>> filter);
    }
}
