namespace FootballPredictor.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using Moq;
    using Xunit;

    public class PlayersServiceTests
    {
        [Fact]
        public void PlayersRankingsMethodReturnCorrectData()
        {
            var teamEnglish = new Team
            {
                Name = "Arsenal",
            };

            var playersList = new List<Player>()
            {
                new Player
                {
                        ShortName = "Name1",
                        Team = teamEnglish,
                        TeamNumber = 1,
                        ScoredGoals = 0,
                        MatchesPlayed = 5,
                },
                new Player
                {
                        ShortName = "Name2",
                        Team = teamEnglish,
                        TeamNumber = 2,
                        ScoredGoals = 2,
                        MatchesPlayed = 5,
                },
                new Player
                {
                        ShortName = "Name3",
                        Team = teamEnglish,
                        TeamNumber = 3,
                        ScoredGoals = 3,
                        MatchesPlayed = 5,
                },
                new Player
                {
                        ShortName = "Name4",
                        Team = teamEnglish,
                        TeamNumber = 4,
                        ScoredGoals = 4,
                        MatchesPlayed = 5,
                },
                new Player
                {
                        ShortName = "Name5",
                        Team = teamEnglish,
                        TeamNumber = 5,
                        ScoredGoals = 5,
                        MatchesPlayed = 5,
                },
                new Player
                {
                        ShortName = "Name6",
                        Team = teamEnglish,
                        TeamNumber = 6,
                        ScoredGoals = 6,
                        MatchesPlayed = 5,
                },
                new Player
                {
                        ShortName = "Name7",
                        Team = teamEnglish,
                        TeamNumber = 7,
                        ScoredGoals = 7,
                        MatchesPlayed = 5,
                },
                new Player
                {
                        ShortName = "Name8",
                        Team = teamEnglish,
                        TeamNumber = 8,
                        ScoredGoals = 8,
                        MatchesPlayed = 5,
                },
                new Player
                {
                        ShortName = "Name9",
                        Team = teamEnglish,
                        TeamNumber = 9,
                        ScoredGoals = 9,
                        MatchesPlayed = 5,
                },
                new Player
                {
                        ShortName = "Name10",
                        Team = teamEnglish,
                        TeamNumber = 10,
                        ScoredGoals = 10,
                        MatchesPlayed = 5,
                },
                new Player
                {
                        ShortName = "Name11",
                        Team = teamEnglish,
                        TeamNumber = 11,
                        ScoredGoals = 11,
                        MatchesPlayed = 5,
                },

            };

            var leagueList = new List<League>()
            {
                new League
                {
                    Id = 1,
                    Name = "English Premier Division",
                    Players = playersList,
                },
                new League
                {
                    Id = 2,
                    Name = "Bundesliga",
                },
            };

            var leagueRepo = new Mock<IDeletableEntityRepository<League>>();
            leagueRepo.Setup(x => x.All()).Returns(leagueList.AsQueryable());

            var service = new PlayersService(leagueRepo.Object);

            var leagues = service.Rankings();
            var leaguesCount = leagues.Leagues.Count();
            var leagueName = leagues.Leagues.Select(x => x.LeagueName).FirstOrDefault();

            var league = leagues.Leagues.FirstOrDefault();
            var leaguePlayersCount = league.Players.Count();

            var playerName = league.Players.Select(x => x.Neam).FirstOrDefault();
            var teamName = league.Players.Select(x => x.TeamName).FirstOrDefault();
            var teamNumber = league.Players.Select(x => x.TeamNumber).FirstOrDefault();
            var scoredGoals = league.Players.Select(x => x.ScoredGoals).FirstOrDefault();
            var matchesPlayed = league.Players.Select(x => x.MatchesPlayed).FirstOrDefault();

            Assert.Equal(2, leaguesCount);
            Assert.Equal("English Premier Division", leagueName);
            Assert.Equal(10, leaguePlayersCount);
            Assert.Equal("Name11", playerName);
            Assert.Equal("Arsenal", teamName);
            Assert.Equal(11, teamNumber);
            Assert.Equal(11, scoredGoals);
            Assert.Equal(5, matchesPlayed);
        }
    }
}
