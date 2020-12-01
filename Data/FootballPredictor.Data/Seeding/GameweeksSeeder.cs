namespace FootballPredictor.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FootballPredictor.Data.Models;

    public class GameweeksSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var gameweeks = new List<Gameweek>();

            for (int i = 0; i < 38; i++)
            {
                gameweeks.Add(new Gameweek());
            }

            await dbContext.Gameweeks.AddRangeAsync(gameweeks);
            await dbContext.SaveChangesAsync();

        }
    }
}
