using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebApp_HaidarAldiWintoro_ManageCompany.Contants;

namespace WebApp_HaidarAldiWintoro_ManageCompany.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
        }
    }
}
