using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        }
    }
}