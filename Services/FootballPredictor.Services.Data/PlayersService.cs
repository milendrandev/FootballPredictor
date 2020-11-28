namespace FootballPredictor.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
            var leagues = this.leagueRepository.All().ToList();
            var rankingsLeagues = new ListOfRankigsViewModel();

            foreach (var league in leagues)
            {
                var players = this.playerRepository.All().Where(p => p.LeagueId == league.Id).ToList();

                rankingsLeagues = new ListOfRankigsViewModel
                {
                    Leagues = leagues.Select(l => new ListOfRankingPlayerViewModel
                    {
                        LeagueName = l.Name,
                        Players = players.Select(p => new RankingPlayerViewModel
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
            }

            return rankingsLeagues;
        }
    }
}
