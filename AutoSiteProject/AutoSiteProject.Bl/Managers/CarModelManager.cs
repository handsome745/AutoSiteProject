using System.Linq;
using AutoMapper;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.Managers
{
    public class CarModelManager : RepositoryManager<CarModel, CarModelViewModel>
    {
        public override CarModelViewModel GetById(int id)
        {
            return Mapper.Map<CarModel, CarModelViewModel>(Repository.FindBy(c => c.Id == id).FirstOrDefault());
        }
        public override void Delete(CarModelViewModel entity)
        {
            Repository.Delete(e => e.Id == entity.Id);
            Repository.Save();
        }
    }
}
