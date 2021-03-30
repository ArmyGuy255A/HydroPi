using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroPi.Repository.Interfaces
{
    public interface IMongoEntity : IEntity
    {
        new string Id { get; set; }
    }
}
