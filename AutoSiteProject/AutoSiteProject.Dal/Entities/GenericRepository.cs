using AutoSiteProject.Models.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Dal.Entities
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public virtual IEnumerable<T> GetAll()
        {

            IEnumerable<T> query = _unitOfWork.Set<T>().ToList();
            return query;
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _unitOfWork.Set<T>().Where(predicate);
            return query;
        }
        public T GetById(int id)
        {
            return _unitOfWork.Set<T>().Find(id);
        }

        public virtual void Add(T entity)
        {
            _unitOfWork.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _unitOfWork.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _unitOfWork.Set<T>().Attach(entity);
        }

    }
}
