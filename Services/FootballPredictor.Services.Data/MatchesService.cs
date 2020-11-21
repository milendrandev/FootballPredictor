namespace FootballPredictor.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FootballPredictor.Common;
    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Web.ViewModels.Matches;

    public class MatchesService : IMatchesService
    {
        private readonly IDeletableEntityRepository<Match> matchRepository;
        private readonly IDeletableEntityRepository<Team> teamRepository;

        public MatchesService(
            IDeletableEntityRepository<Match> matchRepository
            , IDeletableEntityRepository<Team> teamRepository)
        {
            this.matchRepository = matchRepository;
            this.teamRepository = teamRepository;
        }

        public ICollection<AllMatchesForTheWeekViewModel> GetAll()
        {
            var matches = this.matchRepository.AllAsNoTracking().Where(m => m.GameWeek == 1)
                .Select(m => new AllMatchesForTheWeekViewModel
                {
                    Id = m.Id,
                    LeagueId = m.LeagueId,
                    HomeName = this.teamRepository.AllAsNoTracking().Where(t => t.Id == m.HomeTeamId).Select(t => t.Name).FirstOrDefault(),
                    AwayName = this.teamRepository.AllAsNoTracking().Where(t => t.Id == m.AwayTeamId).Select(t => t.Name).FirstOrDefault(),
                    LeagueName = m.League.Name,
                    GameWeek = m.GameWeek,
                }).ToList();

            return matches;
        }

        public void Simulate()
        {
            var matches = this.matchRepository.All().Where(m => m.GameWeek == 1).ToList();

            var random = new Random();

            foreach (var match in matches)
            {
                var homeTeamId = 0;
                var awayTeamId = 0;
                match.HomeGoals = random.Next(10) + 1;
                match.AwayGoals = random.Next(10) + 1;

                homeTeamId = match.HomeTeamId;
                awayTeamId = match.AwayTeamId;

                var homeTeam = this.teamRepository.All().Where(t => t.Id == homeTeamId).FirstOrDefault();
                var awayTeam = this.teamRepository.All().Where(t => t.Id == awayTeamId).FirstOrDefault();

                if (match.HomeGoals > match.AwayGoals)
                {
                    match.ResultType = FootballPredictor.Data.Models.Enums.BetType.Home;
                    homeTeam.Points += 3;
                    homeTeam.Wins++;
                    awayTeam.Looses++;
                }
                else if (match.HomeGoals == match.AwayGoals)
                {
                    match.ResultType = FootballPredictor.Data.Models.Enums.BetType.Draw;
                    homeTeam.Points++;
                    awayTeam.Points++;
                    homeTeam.Draws++;
                    awayTeam.Draws++;
                }
                else
                {
                    match.ResultType = FootballPredictor.Data.Models.Enums.BetType.Away;
                    awayTeam.Points += 3;
                    homeTeam.Looses++;
                    awayTeam.Wins++;
                }

                homeTeam.ScoredGoals = match.HomeGoals.Value;
                homeTeam.ConcededGoals = match.AwayGoals.Value;
                homeTeam.MatchesPlayed++;

                awayTeam.ScoredGoals = match.AwayGoals.Value;
                awayTeam.ConcededGoals = match.HomeGoals.Value;
                awayTeam.MatchesPlayed++;

                this.matchRepository.Update(match);
                this.teamRepository.Update(homeTeam);
                this.teamRepository.Update(awayTeam);

                this.matchRepository.SaveChanges();
                this.teamRepository.SaveChanges();
            }
               
        }
    }
}
