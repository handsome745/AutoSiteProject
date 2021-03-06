﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AutoSiteProject.Models.Dal.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {

        IEnumerable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
