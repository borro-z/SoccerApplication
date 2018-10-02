using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SoccerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerApplication.Data
{
    public class DatabaseInitialisation
    {
        public static void InitializeDatabase(IServiceProvider services)
        {
            SeedData(services);
        }

        private async static void SeedData(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            var usermanager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var rolemanager = services.GetRequiredService<RoleManager<IdentityRole>>();


            if (true)
            {
                await rolemanager.CreateAsync(new IdentityRole { Name = "teammanager" });
                var user = new ApplicationUser { Email = "admin@email.com" };
                IdentityResult result = await usermanager.CreateAsync(user, "Pass123$");
                if (result.Succeeded)
                {
                    await usermanager.AddToRoleAsync(user, "teammanager");
                }
            }
        }
    }
}
