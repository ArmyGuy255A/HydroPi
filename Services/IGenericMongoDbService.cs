using HydroPi.Repository.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace HydroPi.Services
{
    public interface IGenericMongoDbService<TEntity>
        where TEntity : class, IMongoEntity
    {
        IMongoCollection<TEntity> Entities {get; set;}
        List<TEntity> Get();
        TEntity Get(string id);
        TEntity Create(TEntity entity);
        void Update(string id, TEntity entityIn);
        void Remove(TEntity entityIn);
        void Remove(string id);
    }
}
