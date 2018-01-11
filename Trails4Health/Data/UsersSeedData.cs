using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public class UsersSeedData
    {
        public static async Task EnsurePopulatedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string adminName = "Admin";
            const string adminPass = "Secret123$";

            const string touristName = "Carlos Alberto";
            const string touristPass = adminPass;

            const string teacherName = "João Paulo";
            const string teacherPass = adminPass;

            // Role Creation

            if (!await roleManager.RoleExistsAsync("Administrador"))
            {
                await roleManager.CreateAsync(new IdentityRole("Administrador"));
            }

            if (!await roleManager.RoleExistsAsync("Turista"))
            {
                await roleManager.CreateAsync(new IdentityRole("Turista"));
            }

            if(!await roleManager.RoleExistsAsync("Professor"))
            {
                await roleManager.CreateAsync(new IdentityRole("Professor"));
            }
           

            ApplicationUser admin = await userManager.FindByNameAsync(adminName);
            if (admin == null)
            {
                admin = new ApplicationUser { UserName = adminName };
                await userManager.CreateAsync(admin, adminPass);
            }

            if (!await userManager.IsInRoleAsync(admin, "Administrador"))
            {
                await userManager.AddToRoleAsync(admin, "Administrador");
            }

            ApplicationUser tourist = await userManager.FindByNameAsync(touristName);
            if (tourist == null)
            {
                tourist = new ApplicationUser { UserName = touristName };
                await userManager.CreateAsync(tourist, touristPass);
            }

            if (!await userManager.IsInRoleAsync(tourist, "Turista"))
            {
                await userManager.AddToRoleAsync(tourist, "Turista");
            }


            ApplicationUser teacher = await userManager.FindByNameAsync(touristName);
            if (teacher == null)
            {
                teacher = new ApplicationUser { UserName = teacherName };
                await userManager.CreateAsync(teacher, teacherPass);
            }

            if (!await userManager.IsInRoleAsync(teacher, "Professor"))
            {
                await userManager.AddToRoleAsync(teacher, "Professor");
            }
        }
    }
}
