using HydroPi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroPi.Data.Interfaces
{
    public interface ISqlEntity : IEntity
    {
        new Guid Id { get; set; }
        public string Name { get; set; }
    }
}
