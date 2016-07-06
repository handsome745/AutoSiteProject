using AutoSiteProject.Models.Dal.Interfaces;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoSiteProject.Dal.Entities
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        protected GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public virtual IEnumerable<T> GetAll()
        {
            IEnumerable<T> query = _unitOfWork.Set<T>().ToList();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _unitOfWork.Set<T>().AsExpandable().Where(predicate);
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
