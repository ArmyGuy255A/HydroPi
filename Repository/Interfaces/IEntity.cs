using System;

namespace HydroPi.Repository.Interfaces
{
    public interface IEntity
    {
        object Id { get; }
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
