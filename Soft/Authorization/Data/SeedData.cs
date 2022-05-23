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
                await AddUser(serviceProvider, "admin@admin.com", "admin@admin.com", "!Admin1234", UserRoles.AdministratorRole,true);
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
        private static async Task AddUser(IServiceProvider SP , string userName , string email, string password , string role , bool emailConfirmed = true)
        {
            var UserManager = SP.GetRequiredService<UserManager<IdentityUser>>();
            var _user = await UserManager.FindByEmailAsync(email);
            if (_user == null)
            {
                var user = new IdentityUser
                {
                    UserName = userName,
                    Email = email,
                    EmailConfirmed = emailConfirmed
                };
                string adminPassword = password;
                var createUser = UserManager.CreateAsync(user, adminPassword).Result;
                if (createUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
