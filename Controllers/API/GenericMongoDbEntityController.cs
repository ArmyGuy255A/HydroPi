﻿using HydroPi.Repository.Interfaces;
using HydroPi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroPi.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericMongoDbEntityController<TEntity, TMongoDbService> : ControllerBase, IGenericMongoDbEntityController<TEntity>
        where TEntity : class, IMongoEntity, new()
        where TMongoDbService : class, IGenericMongoDbService<TEntity>
    {
        private readonly TMongoDbService _mongoDbService;

        public GenericMongoDbEntityController(TMongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        [HttpGet]
        public ActionResult<List<TEntity>> Get() =>
            _mongoDbService.Get();

        [HttpGet("{id}", Name = "GetTEntity")]
        public ActionResult<TEntity> Get(string id)
        {
            var entity = _mongoDbService.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpPost]
        public ActionResult<TEntity> Create(TEntity entity)
        {
            //TEntity s = new TEntity();
            _mongoDbService.Create(entity);

            return CreatedAtRoute("GetTEntity", new { id = entity.Id.ToString() }, entity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, TEntity entityIn)
        {
            var entity = _mongoDbService.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            _mongoDbService.Update(id, entityIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _mongoDbService.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            _mongoDbService.Remove(entity.Id);

            return NoContent();
        }
    }
}
