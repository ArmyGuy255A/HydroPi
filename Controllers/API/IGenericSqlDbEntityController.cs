using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroPi.Controllers.API
{
    public interface IGenericSqlDbEntityController<TEntity>
    {
        [HttpGet]
        Task<IEnumerable<TEntity>> Get();

        [HttpGet]
        ActionResult<TEntity> Get(Guid id);

        [HttpPost]
        ActionResult<TEntity> Create(TEntity entity);

        [HttpPut]
        IActionResult Update(Guid id, TEntity entity);

        [HttpDelete]
        IActionResult Delete(Guid id);
    }
}
