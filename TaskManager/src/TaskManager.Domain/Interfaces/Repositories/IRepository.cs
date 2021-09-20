using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity>
    {
        void Save(TEntity entity);
        void Update(TEntity entity, Func<TEntity, bool> where);
        void Delete(Func<TEntity, bool> where);
        IEnumerable<TEntity> GetAll();
        TEntity Find(Func<TEntity, bool> where);
    }
}
