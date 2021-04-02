using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HydroPi.Data.Contexts;
using HydroPi.Data.Models;

namespace HydroPi.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : GenericSqlDbEntityController<Sensor>
    {
        private readonly ApplicationDbContext _context;

        public SensorsController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
