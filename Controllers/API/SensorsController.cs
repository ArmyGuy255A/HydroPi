using HydroPi.Models;
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
    public class SensorsController : ControllerBase
    {
        private readonly SensorService _sensorService;

        public SensorsController(SensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpGet]
        public ActionResult<List<Sensor>> Get() =>
            _sensorService.Get();

        [HttpGet("{id:length(24)}", Name = "GetSensor")]
        public ActionResult<Sensor> Get(string id)
        {
            var sensor = _sensorService.Get(id);

            if (sensor == null)
            {
                return NotFound();
            }

            return sensor;
        }

        [HttpPost]
        public ActionResult<Sensor> Create(Sensor sensor)
        {
            _sensorService.Create(sensor);

            return CreatedAtRoute("GetSensor", new { id = sensor.Id.ToString() }, sensor);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Sensor sensorIn)
        {
            var sensor = _sensorService.Get(id);

            if (sensor == null)
            {
                return NotFound();
            }

            _sensorService.Update(id, sensorIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var sensor = _sensorService.Get(id);

            if (sensor == null)
            {
                return NotFound();
            }

            _sensorService.Remove(sensor.Id);

            return NoContent();
        }
    }

}
