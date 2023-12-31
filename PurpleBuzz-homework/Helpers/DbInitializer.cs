﻿using Microsoft.AspNetCore.Identity;
using PurpleBuzz_homework.Constants;
using PurpleBuzz_homework.Models;

namespace PurpleBuzz_homework.Helpers
{
    public class DbInitializer
    {
        public async static Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            foreach (var item in Enum.GetValues(typeof(UserRoles)))
            {
                if (!await roleManager.RoleExistsAsync(item.ToString()))
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = item.ToString() });
                }
            }


            if ( await userManager.FindByNameAsync("admin") == null)
            {
                var user = new User
                {
                    fullName = "admin",
                    UserName = "admin",
                    Email = "admin@gmail.com"
                };

                var result = await userManager.CreateAsync(user, "Admin123?");
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        throw new Exception(item.Description);
                    }
                }
                await userManager.AddToRoleAsync(user, UserRoles.Admin.ToString());
            }




        }
    }
}
