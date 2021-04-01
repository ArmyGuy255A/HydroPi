using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HydroPi.Services.Identity
{
    public class IdentityDbValidator
    {
        public static string AdminRole = "Admin";
        public static string[] Roles = new string[] { AdminRole, "Sensor", "Output", "User" };
        public static string FullControlClaim = "FullControl";

        public async static Task<bool> ValidateRoles(RoleManager<ApplicationRole> roleManager, bool remediate = true)
        {
            foreach (var role in Roles)
            {
                if (await roleManager.RoleExistsAsync(role)) {
                    continue;
                } else if (remediate)
                {
                    // Create the missing role
                    await roleManager.AddClaimAsync(new ApplicationRole(role), new Claim("Permission", role.Equals(AdminRole) ? FullControlClaim : "Read")); 
                    continue;
                } else
                {
                    // Do not remediate
                    return false;
                }

            }
            return true;
        }

        public async static Task<bool> ValidateUsersInAdminRole(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            bool remediate = true)
        {
            if (!await roleManager.RoleExistsAsync(AdminRole))
            {
                // Find an admin user
                var admins = await userManager.GetUsersInRoleAsync(AdminRole);
                if (admins.Count == 0)
                {
                    // Admin user does not exist
                    if (remediate)
                    {
                        var adminUser = new ApplicationUser { UserName = "pi", Email = "pi@hydro.com" };
                        await userManager.CreateAsync(adminUser, "hydro");
                        await userManager.AddToRoleAsync(adminUser, AdminRole);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
