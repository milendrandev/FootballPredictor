namespace FootballPredictor.Services.Data
{
    using System.Linq;

    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Web.ViewModels.Players;

    public class PlayersService : IPlayersService
    {
        private readonly IDeletableEntityRepository<League> leagueRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;

        public PlayersService(
            IDeletableEntityRepository<League> leagueRepository,
            IDeletableEntityRepository<Player> playerRepository)
        {
            this.leagueRepository = leagueRepository;
            this.playerRepository = playerRepository;
        }

        public ListOfRankigsViewModel Rankings()
        {
            var leagues = this.leagueRepository.All().Select(l => new
            {
                Name = l.Name,
                Players = l.Players,
                Teams = l.Teams,
            }).ToList();

            var leaguesModel = new ListOfRankigsViewModel
            {
                Leagues = leagues.Select(league => new ListOfRankingPlayerViewModel
                {
                    LeagueName = league.Name,
                    Players = league.Players.Select(p => new RankingPlayerViewModel
                    {
                        Neam = p.ShortName,
                        TeamName = p.Team.Name,
                        TeamNumber = p.TeamNumber,
                        ScoredGoals = p.ScoredGoals,
                        MatchesPlayed = p.MatchesPlayed,
                    })
                       .OrderByDescending(p => p.ScoredGoals)
                       .ThenBy(p => p.MatchesPlayed)
                       .Take(10),
                }),
            };

            return leaguesModel;
        }
    }
}
