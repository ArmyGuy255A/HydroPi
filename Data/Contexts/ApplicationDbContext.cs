using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HydroPi.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HydroPi.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Sensor>().HasData(
                new Sensor { Id = Guid.NewGuid(), Name = "Sensor A" },
                new Sensor { Id = Guid.NewGuid(), Name = "Sensor B" },
                new Sensor { Id = Guid.NewGuid(), Name = "Sensor C" }
                );

            builder.Entity<Output>().HasData(
                new Output { Id = Guid.NewGuid(), Name = "Output A" },
                new Output { Id = Guid.NewGuid(), Name = "Output B" },
                new Output { Id = Guid.NewGuid(), Name = "Output C" }
                );
        }

        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Output> Outputs { get; set; }
    }
}
