namespace FootballPredictor.Services.Data
{
    using System.Linq;

    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Web.ViewModels.Players;
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

        public ListOfPlayerViewModel GetSquad(int id)
        {
            var team = this.teamRepository.All().Where(t => t.Id == id)
                .Select(t => new ListOfPlayerViewModel
                {
                    TeamName = t.Name,
                    Players = t.Players.Select(p => new PlayerViewModel
                    {
                        ShortName = p.ShortName,
                        ScoredGoals = p.ScoredGoals,
                        MatchesPlayed = p.MatchesPlayed,
                        Age = p.Age,
                        DateOfBirth = p.DateOfBirth,
                        HeightCm = p.HeightCm,
                        WeightKg = p.WeightKg,
                        Nationality = p.Nationality,
                        SquadNumber = p.TeamNumber,
                    })
                    .OrderBy(p => p.SquadNumber)
                    .ToList(),
                }).FirstOrDefault();

            return team;
        }

        public TeamDetailViewModel TeamDetails(int id)
        {
            var team = this.teamRepository.AllAsNoTracking().Where(t => t.Id == id).FirstOrDefault();
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
                    GameweekId = m.GameweekId,
                }).OrderBy(m => m.GameweekId),
            };

            return teamModel;
        }
    }
}
