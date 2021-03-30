using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HydroPi.Repository.Interfaces
{
    public interface IReadOnlyRepository<TEntity> : IDisposable
        where TEntity : class
    {
        //IEnumerable<TEntity> GetAll<TEntity>();
        //IEnumerable<TEntity> GetAllAsync<TEntity>();
        //IEnumerable<TEntity> Get<TEntity>();
        //IEnumerable<TEntity> Get<TEntity>(object id);
        //IEnumerable<TEntity> GetAsync<TEntity>();
        //IEnumerable<TEntity> GetAsync<TEntity>(object id);
        //bool Exists<TEntity>(Expression<Func<TEntity, bool>> filter = null);
        //Task<bool> ExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
