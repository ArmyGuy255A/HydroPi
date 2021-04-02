using HydroPi.Repository.Interfaces;

namespace HydroPi.MongoData.Interfaces
{
    public interface IMongoEntity : IEntity
    {
        new string Id { get; set; }
    }
}
