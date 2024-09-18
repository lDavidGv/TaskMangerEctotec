using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(int id);

        void Add(TEntity entity);

        void Delete(TEntity entity);
    }
}