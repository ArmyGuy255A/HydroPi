using HydroPi.Data.Contexts;
using HydroPi.Data.Interfaces;
using HydroPi.MongoData.Interfaces;
using HydroPi.Services.MongoDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HydroPi.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericSqlDbEntityController<TEntity> : ControllerBase, IGenericSqlDbEntityController<TEntity>
        where TEntity : class, ISqlEntity, new()
    {
        private readonly ApplicationDbContext _context;

        public GenericSqlDbEntityController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }


        [HttpGet("{id}", Name = "GetEntity")]
        public ActionResult<TEntity> Get(Guid id)
        {
            var entity = _context.Find<TEntity>(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpPost]
        public ActionResult<TEntity> Create(TEntity entity)
        {
            _context.Add<TEntity>(entity);

            //TODO: Save Changes & Add Unit of Work class
            _context.SaveChanges();

            return CreatedAtRoute("GetEntity", new { id = entity.Id.ToString() }, entity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            _context.Entry<TEntity>(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();

            return NoContent();
        }

        private bool EntityExists(Guid id)
        {
            return _context.Set<TEntity>().Any(e => e.Id == id);
        }
    }
}
