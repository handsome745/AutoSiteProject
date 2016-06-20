using System.Linq;

namespace AutoSiteProject.Models.Bl.Interfaces
{
    public interface IRepositoryManager<T> where T: class 
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(int id);
        void Edit(T entity);
    }
}
