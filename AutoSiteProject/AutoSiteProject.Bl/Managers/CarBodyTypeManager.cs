using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;

namespace AutoSiteProject.Bl.Managers
{
    public class CarBodyTypeManager : RepositoryManager<CarBodyType, CarBodyTypeViewModel>
    {
        public override CarBodyTypeViewModel GetById(int id)
        {
            return Mapper.Map<CarBodyType, CarBodyTypeViewModel>(Repository.FindBy(c => c.Id == id).FirstOrDefault());
        }

        public override void Delete(CarBodyTypeViewModel entity)
        {
            Repository.Delete(e => e.Id == entity.Id);
            Repository.Save();
        }
    }
}
