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
    public class SensorsController : GenericMongoDbEntityController<Sensor, SensorService>
    {

        public SensorsController(SensorService sensorService) : base(sensorService)
        {

        }
    }

}
