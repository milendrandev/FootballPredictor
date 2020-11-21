namespace FootballPredictor.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FootballPredictor.Data.Models;
    using FootballPredictor.Data.Models.ModelsDto;
    using Newtonsoft.Json;

    public class TeamsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Teams.Any())
            {
                return;
            }

            var jsonClubs = Directory.GetFiles("Datasets/Clubs");

            for (int i = 0; i < jsonClubs.Length; i++)
            {
                var json = File.ReadAllText(jsonClubs[i]);
                var teams = new List<Team>();

                var teamsDto = JsonConvert.DeserializeObject<TeamDtoSeeder[]>(json);

                var teamCountry = teamsDto.Select(t => t.Country).FirstOrDefault();
                var leagueId = dbContext.Leagues.Where(l => l.Country == teamCountry).Select(l => l.Id).FirstOrDefault();

                foreach (var teamDto in teamsDto)
                {

                    var team = new Team
                    {
                        Name = teamDto.Name,
                        Code = teamDto.Code,
                        Country = teamDto.Country,
                        LeagueId = leagueId,
                    };

                   await dbContext.Teams.AddAsync(team);
                }

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
