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
        private IGenericRepository<T> _tRepository;
        private IUnitOfWork _unitOfWork;

        public RepositoryManager(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _tRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<T> GetAll()
        {
            var list = _tRepository.GetAll();
            return list;
        }


        public void Add(T entity)
        {
            _tRepository.Add(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            _tRepository.Delete(entity);
            _unitOfWork.Commit();
        }

        public void Edit(T entity)
        {
            _tRepository.Edit(entity);
            _unitOfWork.Commit();
        }

        public virtual T GetById(int id)
        {
            return _tRepository.GetById(id);
        }
    }
}
