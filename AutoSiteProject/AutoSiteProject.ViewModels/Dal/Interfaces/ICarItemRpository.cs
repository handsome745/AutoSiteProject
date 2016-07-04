using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AutoSiteProject.Models.Dal.Interfaces
{
    public interface ICarItemRpository: IGenericRepository<CarItem>
    {
        IQueryable<CarAggregateViewModel> GetCarsAggregateViewModel(Expression<Func<CarAggregateViewModel, bool>> predicate);
    }
}
