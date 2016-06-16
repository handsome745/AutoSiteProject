using System.Collections.Generic;
using System.Linq;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.Dal.Interfaces;

namespace AutoSiteProject.Bl.Managers
{
    public abstract class RepositoryManager<T, TV> : IRepositoryManager<TV>
        where T : class
        where TV: class
    {
        private IGenericRepository<T> _tRepository ;

        public IGenericRepository<T> Repository
        {
            get { return _tRepository; }
            set { _tRepository = value; }
        }

        public IEnumerable<TV> GetAll()
        {
            var list = _tRepository.GetAll().ToList();
            return AutoMapper.Mapper.Map<List<T>, List<TV>>(list);
        }


        public void Add(TV entity)
        {
            _tRepository.Add(AutoMapper.Mapper.Map<TV, T>(entity));
            _tRepository.Save();
        }

        public virtual void Delete(TV entity)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(TV entity)
        {
            _tRepository.Edit(AutoMapper.Mapper.Map<TV, T>(entity));
            _tRepository.Save();
        }

        public virtual TV GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
