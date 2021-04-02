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
    public class IdentityDbContext : IdentityDbContext<HydroPiUser, HydroPiRole, string>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            HydroPiRole adminRole = new HydroPiRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            HydroPiRole userRole = new HydroPiRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "USER"
            };

            builder.Entity<HydroPiRole>().HasData(
                adminRole,
                userRole
            );

        }

    }
}
