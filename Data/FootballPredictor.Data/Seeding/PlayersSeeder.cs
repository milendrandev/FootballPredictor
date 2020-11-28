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

    public class PlayersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Players.Any())
            {
                return;
            }

            var jsonPlayers = File.ReadAllText("Datasets/Players/FilteredPlayers.json");

            var playersDto = JsonConvert.DeserializeObject<PlayerDtoSeeder[]>(jsonPlayers);
            var players = new List<Player>();

            foreach (var playerDto in playersDto)
            {
                var team = dbContext.Teams.Where(t => t.Name == playerDto.ClubName).FirstOrDefault();
                var league = dbContext.Leagues.Where(l => l.Name == playerDto.LeagueName).FirstOrDefault();

                if (team == null || league == null)
                {
                    continue;
                }

                var player = new Player
                {
                    ShortName = playerDto.ShortName,
                    LongName = playerDto.LongName,
                    Age = int.Parse(playerDto.Age),
                    DateOfBirth = playerDto.DateOfBirth,
                    HeightCm = int.Parse(playerDto.HeightCm),
                    WeightKg = int.Parse(playerDto.WeightKg),
                    Nationality = playerDto.Nationality,
                    TeamNumber = playerDto.TeamNumber,
                    Team = team,
                    League = league,
                };

                league.Players.Add(player);
                players.Add(player);
            }

            await dbContext.Players.AddRangeAsync(players);
            await dbContext.SaveChangesAsync();
        }
    }
}
