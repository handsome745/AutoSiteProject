using System;
using System.Data.Entity;

namespace AutoSiteProject.Models.Dal.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        void Commit();
    }
}
