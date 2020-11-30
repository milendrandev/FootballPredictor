namespace FootballPredictor.Services.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Web.ViewModels.Matches;

    public class MatchesService : IMatchesService
    {
        private readonly IDeletableEntityRepository<Match> matchRepository;
        private readonly IDeletableEntityRepository<Team> teamRepository;
        private readonly IDeletableEntityRepository<League> leagueRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;

        public MatchesService(
            IDeletableEntityRepository<Match> matchRepository,
            IDeletableEntityRepository<Team> teamRepository,
            IDeletableEntityRepository<League> leagueRepository,
            IDeletableEntityRepository<Player> playerRepository)
        {
            this.matchRepository = matchRepository;
            this.teamRepository = teamRepository;
            this.leagueRepository = leagueRepository;
            this.playerRepository = playerRepository;
        }

        public ListOfLeaguesViewModel GetAll()
        {
            var listLeagues = new ListOfLeaguesViewModel
            {
                Leagues = this.leagueRepository.All().Select(l => new ListOfMatchesViewModel
                {
                    LeagueId = l.Id,
                    LeagueName = l.Name,
                    Matches = l.Matches.Where(m => m.GameWeek == 1).Select(m => new AllMatchesForTheWeekViewModel
                    {
                        Id = m.Id,
                        HomeName = this.teamRepository.AllAsNoTracking().Where(t => t.Id == m.HomeTeamId).Select(t => t.Name).FirstOrDefault(),
                        AwayName = this.teamRepository.AllAsNoTracking().Where(t => t.Id == m.AwayTeamId).Select(t => t.Name).FirstOrDefault(),
                        GameWeek = m.GameWeek,
                    }),
                }).ToList(),
            };

            return listLeagues;
        }

        public void Simulate()
        {
            var matches = this.matchRepository.All().Where(m => m.GameWeek == 1).ToList();

            var random = new Random();

            foreach (var match in matches)
            {
                var homeTeamId = 0;
                var awayTeamId = 0;
                match.HomeGoals = random.Next(6) + 1;
                match.AwayGoals = random.Next(6) + 1;

                homeTeamId = match.HomeTeamId;
                awayTeamId = match.AwayTeamId;

                var homeTeam = this.teamRepository.All().Where(t => t.Id == homeTeamId).FirstOrDefault();
                var awayTeam = this.teamRepository.All().Where(t => t.Id == awayTeamId).FirstOrDefault();

                var homePlayers = this.teamRepository.All().Where(t => t.Id == homeTeamId)
                    .Select(t => t.Players.OrderBy(p => p.TeamNumber).Take(11)).FirstOrDefault();

                var awayPlayers = this.teamRepository.All().Where(t => t.Id == awayTeamId)
                   .Select(t => t.Players.OrderBy(p => p.TeamNumber).Take(11)).FirstOrDefault();

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

                this.PlayedPlayers(homePlayers, awayPlayers, homeTeam.ScoredGoals, awayTeam.ScoredGoals);

            }

            this.matchRepository.SaveChanges();
            this.teamRepository.SaveChanges();
        }

        private void PlayedPlayers(IEnumerable<Player> homePlayers, IEnumerable<Player> awayPlayers, int homeGoals, int awayGoals)
        {
            var random = new Random();

            var playedPlayers = new List<Player>();
            var homePlayersList = new List<Player>();
            var awayPlayersList = new List<Player>();

            homePlayersList.AddRange(homePlayers);
            awayPlayersList.AddRange(awayPlayers);

            playedPlayers.AddRange(homePlayers);
            playedPlayers.AddRange(awayPlayers);

            foreach (var player in playedPlayers)
            {
                player.MatchesPlayed++;

                this.playerRepository.Update(player);
            }

            for (int i = 0; i < homeGoals; i++)
            {
                var scorePlayerIndex = random.Next(homePlayers.Count());

                var scorePlayer = homePlayersList[scorePlayerIndex];

                scorePlayer.ScoredGoals++;

                this.playerRepository.Update(scorePlayer);
            }

            for (int i = 0; i < awayGoals; i++)
            {
                var scorePlayerIndex = random.Next(awayPlayers.Count());

                var scorePlayer = awayPlayersList[scorePlayerIndex];

                scorePlayer.ScoredGoals++;

                this.playerRepository.Update(scorePlayer);
            }
        }
    }
}
