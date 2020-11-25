namespace FootballPredictor.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Web.ViewModels.Teams;

    public class TeamsService : ITeamsService
    {
        private readonly IDeletableEntityRepository<Team> teamRepository;
        private readonly IDeletableEntityRepository<Match> matchRepository;

        public TeamsService(IDeletableEntityRepository<Team> teamRepository, IDeletableEntityRepository<Match> matchRepository)
        {
            this.teamRepository = teamRepository;
            this.matchRepository = matchRepository;
        }

        public TeamDetailViewModel TeamDetails(int teamId)
        {
            var team = this.teamRepository.AllAsNoTracking().Where(t => t.Id == teamId).FirstOrDefault();
            var matches = this.matchRepository.AllAsNoTracking()
                .Where(m => m.HomeTeamId == team.Id || m.AwayTeamId == team.Id).ToList();

            foreach (var match in matches)
            {
                team.Matches.Add(match);
            }


            var teamModel = new TeamDetailViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Matches = team.Matches.Select(m => new MatchDetailViewModel
                {
                    HomeGoals = m.HomeGoals,
                    AwayGoals = m.AwayGoals,
                    HomeName = this.teamRepository.All().Where(t => t.Id == m.HomeTeamId).Select(t => t.Name).FirstOrDefault(),
                    AwayName = this.teamRepository.All().Where(t => t.Id == m.AwayTeamId).Select(t => t.Name).FirstOrDefault(),
                }),
            };

            return teamModel;
        }
    }
}
