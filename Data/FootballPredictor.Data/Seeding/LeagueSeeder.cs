namespace FootballPredictor.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using FootballPredictor.Data.Models;
    using FootballPredictor.Data.Models.ModelsDto;
    using Newtonsoft.Json;

    public class LeagueSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Leagues.Any())
            {
                return;
            }

            var leagues = this.AddLeagues();

            await dbContext.Leagues.AddRangeAsync(leagues);
            await dbContext.SaveChangesAsync();
        }

        private List<League> AddLeagues()
        {
            string json = File.ReadAllText("Datasets/Leagues.json");
            var leagues = JsonConvert.DeserializeObject<LeagueDtoSeeder[]>(json);
            var list = new List<League>();

            foreach (var leagueDto in leagues)
            {
                var league = new League
                {
                    Name = leagueDto.Name,
                    Country = leagueDto.Country,
                };
                list.Add(league);
            }

            return list;
        }
    }
}
