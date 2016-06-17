using AutoSiteProject.Models.Dal.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Dal.Entities
{
    public abstract class GenericRepository<C, T> : IGenericRepository<T>
        where T : WithId 
        where C : DbContext, new()
    {

        private C _entities = new C();
        public C Context
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var entities = _entities.Set<T>().Where(predicate);
            _entities.Set<T>().RemoveRange(entities);
        }

        public virtual void Edit(T entity)
        {
            var dbEntity = _entities.Set<T>().FirstOrDefault(e => e.Id == entity.Id);
            _entities.Entry(dbEntity).CurrentValues.SetValues(entity);
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
