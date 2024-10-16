using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;
using IMF.DAL.Identity;
using System.Collections.Generic;

namespace IMF.Api.Configurations
{
    public static class SeedData
    {
        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            var roles = new List<ApplicationRole>
            {
                new ApplicationRole { Name = "SystemAdmin", LastModified = DateTime.UtcNow, IsSysAdmin = true, RoleDescription = "System Administrator Role" },
                new ApplicationRole { Name = "CompanyAdmin", LastModified = DateTime.UtcNow, IsSysAdmin = false, RoleDescription = "Company Administrator Role" },
                new ApplicationRole { Name = "CompanyUser", LastModified = DateTime.UtcNow, IsSysAdmin = false, RoleDescription = "User Role for Handle Company" },
                new ApplicationRole { Name = "DeleteAdmin", LastModified = DateTime.UtcNow, IsSysAdmin = false, RoleDescription = "Delete Any Entity Role" }
            };

            foreach (var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role.Name);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(role);
                }
            }
        }

    }
}
