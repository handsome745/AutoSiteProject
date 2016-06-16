using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoSiteProject.Models.Bl.Interfaces
{
    public interface IRepositoryManager<T> where T: class 
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
