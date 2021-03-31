namespace HydroPi.Repository.Interfaces
{
    public interface IMongoEntity : IEntity
    {
        new string Id { get; set; }
    }
}
