using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroPi.Controllers.API
{
    public interface IGenericMongoDbEntityController<TEntity>
    {
        [HttpGet]
        ActionResult<List<TEntity>> Get();

        [HttpGet("{id:length(24)}", Name = "GetTEntity")]
        ActionResult<TEntity> Get(string id);

        [HttpPost]
        ActionResult<TEntity> Create(TEntity TEntity);

        [HttpPut("{id:length(24)}")]
        IActionResult Update(string id, TEntity TEntityIn);

        [HttpDelete("{id:length(24)}")]
        IActionResult Delete(string id);
    }
}
