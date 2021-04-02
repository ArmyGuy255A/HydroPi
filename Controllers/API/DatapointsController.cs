using HydroPi.MongoData.Models;
using HydroPi.Services.MongoDb;
using Microsoft.AspNetCore.Mvc;

namespace HydroPi.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class DatapointsController : GenericSqlDbEntityController<Datapoint, DataPointService>
    {

        public DatapointsController(DataPointService sensorService) : base(sensorService)
        {

        }
    }

}
