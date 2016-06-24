using AutoSiteProject.Models.Dal.Interfaces;
using System.Data.Entity;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Dal.Entities
{
    public class UnitOfWork: IUnitOfWork
    {
        readonly AutoSiteProjectDBEntities _context;
        private bool _isDisposed;

        public UnitOfWork(AutoSiteProjectDBEntities context)
        {
            _context = context;
        }

        public DbSet<T> Set<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_isDisposed)
                return;

            _isDisposed = true;
            _context.Dispose();
        }
    }
}
