using System.Collections.Generic;
using System.Linq;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Bl.Managers
{
    public abstract class RepositoryManager<T> : IRepositoryManager<T>
        where T : class 
    {
        private IGenericRepository<T> _tRepository ;

        public IGenericRepository<T> Repository
        {
            get { return _tRepository; }
            set { _tRepository = value; }
        }

        public IQueryable<T> GetAll()
        {
            var list = _tRepository.GetAll();
            return list;
        }


        public void Add(T entity)
        {
            _tRepository.Add(entity);
            _tRepository.Save();
        }

        public virtual void Delete(T entity)
        {
            _tRepository.Delete(entity);
            _tRepository.Save();
        }

        public void Edit(T entity)
        {
            _tRepository.Edit(entity);
            _tRepository.Save();
        }

        public virtual T GetById(int id)
        {
            return _tRepository.GetById(id);
        }
    }
}
