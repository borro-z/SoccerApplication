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
        public static void InitializeDatabase(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                ApplicationRole role = new ApplicationRole
                {
                    Name = "NormalUser",
                    Description = "Perform normal operations."
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("TeamManager").Result)
            {
                ApplicationRole role = new ApplicationRole
                {
                    Name = "TeamManager",
                    Description = "Manage players"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                ApplicationRole role = new ApplicationRole
                {
                    Name = "Administrator",
                    Description = "Perform all the operations."
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@email.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@email.com";
                user.Email = "admin@email.com";

                IdentityResult result = userManager.CreateAsync
                (user, "Pass123$").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "TeamManager").Wait();
                }
            }


            if (userManager.FindByNameAsync("admin1@email.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin1@email.com";
                user.Email = "admin1@email.com";

                IdentityResult result = userManager.CreateAsync
                (user, "Pass123$").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "TeamManager").Wait();
                }
            }
        }
    }
}
