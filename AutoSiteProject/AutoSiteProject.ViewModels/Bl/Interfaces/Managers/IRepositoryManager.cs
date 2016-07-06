using System.Collections.Generic;

namespace AutoSiteProject.Models.Bl.Interfaces.Managers
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
