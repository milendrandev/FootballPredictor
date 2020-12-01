namespace FootballPredictor.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FootballPredictor.Data.Models;
    using TournamentScheduling;

    public class MatchsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Matches.Any())
            {
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                var league = dbContext.Leagues.FirstOrDefault(m => m.Matches.Count == 0);
                var teams = league.Teams.Select(t => t.Id).ToArray();

                var matches = new List<Match>();

                var roundingResult = new RoundRobinAlgorithm().GetCalculatedSchedule(teams.Count());
                var gameweek = 1;

                foreach (var rounding3rdLevel in roundingResult)
                {
                    foreach (var rounding2ndLevel in rounding3rdLevel)
                    {
                        for (int round = 0; round < rounding2ndLevel.Length; round += 2)
                        {
                            var homeTeamId = teams[rounding2ndLevel[0] - 1];
                            var awayTeamId = teams[rounding2ndLevel[1] - 1];

                            matches.Add(new Match
                            {
                                HomeTeamId = homeTeamId,
                                AwayTeamId = awayTeamId,
                                LeagueId = league.Id,
                                GameweekId = gameweek,

                            });
                        }
                    }

                    gameweek++;
                }

                foreach (var rounding3rdLevel in roundingResult)
                {
                    foreach (var rounding2ndLevel in rounding3rdLevel)
                    {
                        for (int round = 0; round < rounding2ndLevel.Length; round += 2)
                        {
                            var homeTeamId = teams[rounding2ndLevel[1] - 1];
                            var awayTeamId = teams[rounding2ndLevel[0] - 1];

                            matches.Add(new Match
                            {
                                HomeTeamId = homeTeamId,
                                AwayTeamId = awayTeamId,
                                LeagueId = league.Id,
                                GameweekId = gameweek,

                            });
                        }
                    }
                    gameweek++;
                }
                await dbContext.Matches.AddRangeAsync(matches);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
