namespace FootballPredictor.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using FootballPredictor.Common;
    using FootballPredictor.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class UsersToRoleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByEmailAsync("milendrandev@abv.bg");

            if (user == null)
            {
                return;
            }

            await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
        }
    }
}
