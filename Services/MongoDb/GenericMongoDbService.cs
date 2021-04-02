using HydroPi.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using HydroPi.MongoData.Interfaces;

namespace HydroPi.Services.MongoDb
{
    public abstract class GenericMongoDbService<TEntity> : IGenericMongoDbService<TEntity>
        where TEntity : class, IMongoEntity
    {
        public readonly IMongoCollection<TEntity> _entities;
        public IMongoCollection<TEntity> Entities { get; set; }
        public GenericMongoDbService()
        {
            
            
        }

        public GenericMongoDbService(IOptionsMonitor<HydroPiDatabaseSettings> databaseSettings, string collectionName) : this()
        {
            var client = new MongoClient(databaseSettings.CurrentValue.ConnectionString);
            //var client = new MongoClient("mongodb://pi:hydro@127.0.0.1:27017");
            var database = client.GetDatabase(databaseSettings.CurrentValue.DatabaseName);
            _entities = database.GetCollection<TEntity>(collectionName);
            Entities = _entities;
        }

        public List<TEntity> Get() =>
            _entities.Find(entity => true).ToList();

        public TEntity Get(string id) =>
            _entities.Find<TEntity>(entity => entity.Id == id).FirstOrDefault();

        public TEntity Create(TEntity entity)
        {

            if (null == entity.Id || entity.Id.Length <= 24)
            {
                entity.Id = String.Format("{0}_{1}", entity.GetType().Name, ObjectId.GenerateNewId().ToString());
            }
            _entities.InsertOne(entity);
            return entity;
        }

        public void Update(string id, TEntity entityIn) =>
            _entities.ReplaceOne(entity => entity.Id == id, entityIn);

        public void Remove(TEntity entityIn) =>
            _entities.DeleteOne(entity => entity.Id == entityIn.Id);

        public void Remove(string id) =>
            _entities.DeleteOne(entity => entity.Id == id);
    }

    
}
