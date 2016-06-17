using System.Linq;
using AutoMapper;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.Managers
{
    public class ManufacturerManager : RepositoryManager<Manufacturer, ManufacturerViewModel>
    {
        public override ManufacturerViewModel GetById(int id)
        {
            return Mapper.Map<Manufacturer, ManufacturerViewModel>(Repository.FindBy(c => c.Id == id).FirstOrDefault());
        }
        public override void Delete(ManufacturerViewModel entity)
        {
            Repository.Delete(e => e.Id == entity.Id);
            Repository.Save();
        }
    }
}
