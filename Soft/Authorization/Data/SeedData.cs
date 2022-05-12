using eSportSchool.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Soft.Authorization.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                       serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                await EnsureRole(serviceProvider, UserRoles.AdministratorRole);
                await EnsureRole(serviceProvider, UserRoles.TrainerRole);
                await EnsureRole(serviceProvider, UserRoles.UserRole);
                var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var _user = await UserManager.FindByEmailAsync("admin@admin.com");
                if (_user == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = "admin@admin.com",
                        Email = "admin@admin.com",
                        EmailConfirmed = true
                    };
                    string adminPassword = "!Admin1234";
                    var createUser = UserManager.CreateAsync(user, adminPassword).Result;
                    if (createUser.Succeeded)
                    {
                        //here we tie the new user to the role
                        await UserManager.AddToRoleAsync(user, UserRoles.AdministratorRole);
                    }
                }
            }
        }
        private static async Task EnsureRole(IServiceProvider serviceProvider, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            if (roleManager == null) { throw new Exception("roleManager null"); }
            if (!await roleManager.RoleExistsAsync(role))
            {
                IdentityResult IR = await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
