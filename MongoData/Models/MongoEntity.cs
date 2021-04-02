using HydroPi.MongoData.Interfaces;
using HydroPi.Repository.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.ComponentModel.DataAnnotations;

namespace HydroPi.MongoData.Models
{
    public abstract class MongoEntity : IMongoEntity
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        object IEntity.Id
        {
            get { return this.Id; }
        }

        [BsonElement("Name")]
        public string Name { get; set; }

        private DateTime? createdDate;
        [BsonElement("CreatedDate")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }

        [BsonElement("CreatedBy")]
        public string CreatedBy { get; set; }
    }
}