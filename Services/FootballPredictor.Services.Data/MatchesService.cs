namespace FootballPredictor.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Web.ViewModels.Matches;

    public class MatchesService : IMatchesService
    {
        private readonly IDeletableEntityRepository<Match> deletableEntityRepository;
        private readonly IDeletableEntityRepository<Team> deletableEntityTeamRepository;

        public MatchesService(IDeletableEntityRepository<Match> deletableEntityRepository
            , IDeletableEntityRepository<Team> deletableEntityTeamRepository)
        {
            this.deletableEntityRepository = deletableEntityRepository;
            this.deletableEntityTeamRepository = deletableEntityTeamRepository;
        }

        public ICollection<AllMatchesForTheWeekViewModel> GetAll()
        {
            var matches = this.deletableEntityRepository.AllAsNoTracking().Where(m => m.GameWeek == 1)
                .Select(m=> new AllMatchesForTheWeekViewModel
                {
                    Id = m.Id,
                    LeagueId = m.LeagueId,
                    HomeName = this.deletableEntityTeamRepository.AllAsNoTracking().Where(t=> t.Id == m.HomeTeamId).Select(t=> t.Name).FirstOrDefault(),
                    AwayName = this.deletableEntityTeamRepository.AllAsNoTracking().Where(t => t.Id == m.AwayTeamId).Select(t => t.Name).FirstOrDefault(),
                    LeagueName = m.League.Name,
                    GameWeek = m.GameWeek,
                }).ToList();

            return matches;
        }
    }
}
