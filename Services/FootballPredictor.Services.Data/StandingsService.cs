using FootballPredictor.Data.Common.Repositories;
using FootballPredictor.Data.Models;
using FootballPredictor.Web.ViewModels.Standings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballPredictor.Services.Data
{
    public class StandingsService : IStandingsService
    {
        private readonly IDeletableEntityRepository<League> leagueRepository;

        public StandingsService(IDeletableEntityRepository<League> leagueRepository)
        {
            this.leagueRepository = leagueRepository;
        }

        public LeagueViewModel LeagueStandings(string leagueName)
        {
            var league = this.leagueRepository.AllAsNoTracking().Where(l => l.Name == leagueName)
                .Select(l => new LeagueViewModel
                {
                    Name = l.Name,
                    Teams = l.Teams.Select(t => new TeamViewModel
                    {
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
                    .ToList(),
                }).FirstOrDefault();

            return league;
        }
    }
}
