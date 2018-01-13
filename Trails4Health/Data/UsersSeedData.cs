using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Trails4Health.Data;

namespace Trails4Health.Models
{
    public class UsersSeedData
    {

        public static async Task EnsurePopulatedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, UsersDbContext dbContext)
        {
            const string adminName = "Admin";
            const string adminPass = "Secret123$";
            const string teacherName = "professor";
            const string teacherPass = adminPass;
            const string turistaName = "turista";
            const string turistaPass = adminPass;


            if (!await roleManager.RoleExistsAsync("Administrador"))
            {
                await roleManager.CreateAsync(new IdentityRole("Administrador"));
            }

            if (!await roleManager.RoleExistsAsync("Turista"))
            {
                await roleManager.CreateAsync(new IdentityRole("Turista"));
            }

            if (!await roleManager.RoleExistsAsync("Professor"))
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

            ApplicationUser turista = await userManager.FindByNameAsync(turistaName);
            if (turista == null)
            {
                turista = new ApplicationUser { UserName = turistaName };
                await userManager.CreateAsync(turista, turistaPass);
            }

            if (!await userManager.IsInRoleAsync(turista, "Turista"))
            {
                await userManager.AddToRoleAsync(turista, "Turista");
            }

            ApplicationUser professor = await userManager.FindByNameAsync(teacherName);
            if (professor == null)
            {
                professor = new ApplicationUser { UserName = teacherName };
                await userManager.CreateAsync(professor, teacherPass);
            }

            if (!await userManager.IsInRoleAsync(professor, "Professor"))
            {
                await userManager.AddToRoleAsync(professor, "Professor");
            }

            Tourist t1 = new Tourist { Name = "João Silva", DateOfBirth = new DateTime(1991, 11, 10), CC = "14255115", Phone = "926263545", Email = "joao@gmail.com" };
            Tourist t2 = new Tourist { Name = "Carlos Alberto", DateOfBirth = new DateTime(1986, 10, 23), CC = "14255123", Phone = "926263245", Email = "carlos@gmail.com" };

            if (t1 == null)
            {
                NotFound("Tourist NULL");
            }

            if (userManager == null)
            {
                NotFound("userManager NULL");
            }


            if (dbContext == null)
            {
                NotFound("dbContext NULL");
            }

            var user = new ApplicationUser { UserName = t1.Email, Email = t1.Email };
            var result = userManager.CreateAsync(user, "Teste12!");
            await userManager.AddToRoleAsync(user, "Turista");
            dbContext.Add(t1);
            await dbContext.SaveChangesAsync();


        }

        private static object NotFound(string v)
        {
            throw new NotImplementedException();
        }

        /* public static async Task PopulateAccount(Tourist t1, UserManager<ApplicationUser> userManager, UsersDbContext dbContext)
         {

         }*/

    }


}
