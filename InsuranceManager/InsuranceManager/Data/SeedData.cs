using Microsoft.AspNetCore.Identity;

namespace InsuranceManager.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManger = serviceProvider.GetRequiredService<RoleManager<IdentityUser>>();

            //Define Roles
            List<string> roleNames = new List<string> {"Admin", "User"};
            IdentityResult roleResult;

        }
    }
}
