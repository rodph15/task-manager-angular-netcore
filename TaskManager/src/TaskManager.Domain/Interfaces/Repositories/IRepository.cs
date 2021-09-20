using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity>
    {
        void Save(TEntity entity);
        void Update(IEnumerable<TEntity> entityList);
        void Delete(Func<TEntity, bool> where);
        IEnumerable<TEntity> GetAll();
    }
}
