using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace StudyWithMe.WebUI.Identity
{
    public class SeedIdentity
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {   
            // SeedRoles
            var roleBroadcaster = configuration["Data:RoleBroadcaster:name"];
            var roleUser = configuration["Data:RoleUser:name"];
            if (await roleManager.FindByNameAsync(roleUser) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleUser));
            }
            if (await roleManager.FindByNameAsync(roleBroadcaster) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleBroadcaster));
            }

            // SeedUsers
            var username = configuration["Data:BroadcasterUser:username"];
            var email = configuration["Data:BroadcasterUser:email"];
            var password = configuration["Data:BroadcasterUser:password"];
            var role = configuration["Data:BroadcasterUser:role"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                var user = new User()
                {
                    UserName = username,
                    Email = email,
                    FirstName = "broadcaster",
                    LastName = "broadcaster",
                    EmailConfirmed = true,
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

        }

        // private static async Task SeedRoles(RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        // {
        //     var roleBroadcaster = configuration["Data:BroadcastingRole:name"];
        //     var roleUser = configuration["Data:BroadcastingRole:name"];
        //     if (await roleManager.FindByNameAsync(roleUser) == null)
        //     {
        //         await roleManager.CreateAsync(new IdentityRole(roleUser));
        //     }
        //     if (await roleManager.FindByNameAsync(roleBroadcaster) == null)
        //     {
        //         await roleManager.CreateAsync(new IdentityRole(roleBroadcaster));
        //     }
        // }
    }
}