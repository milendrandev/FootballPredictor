namespace FootballPredictor.Services.Data
{
    using System.Linq;

    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Web.ViewModels.Standings;

    public class StandingsService : IStandingsService
    {
        private readonly IDeletableEntityRepository<League> leagueRepository;

        public StandingsService(IDeletableEntityRepository<League> leagueRepository)
        {
            this.leagueRepository = leagueRepository;
        }

        public LeagueViewModel LeagueStandings(string leagueName)
        {
            var league = this.leagueRepository.All().Where(l => l.Name == leagueName)
                .Select(l => new LeagueViewModel
                {
                    Name = l.Name,
                    Teams = l.Teams.Select(t => new TeamViewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Wins = t.Wins,
                        Draws = t.Draws,
                        Looses = t.Looses,
                        ScoredGoals = t.ScoredGoals,
                        ConcededGoals = t.ConcededGoals,
                        MatchesPlayed = t.MatchesPlayed,
                        Points = t.Points,
                    })
                    .OrderByDescending(t => t.Points)
                    .ThenByDescending(t => t.ScoredGoals - t.ConcededGoals)
                    .ThenByDescending(t => t.ScoredGoals)
                    .ThenByDescending(t => t.ConcededGoals)
                    .ThenBy(t => t.Name)
                    .ToList(),
                }).FirstOrDefault();

            return league;
        }
    }
}
