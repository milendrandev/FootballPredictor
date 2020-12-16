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

    public class StandingsServiceTests
    {
        [Fact]
        public void LeagueStandingsMethodReturnTheRightLeague()
        {
            var teamsList = new List<Team>()
            {
                new Team
                {
                        Id = 1,
                        Name = "Arsenal",
                        Wins = 3,
                        Draws = 1,
                        Looses = 0,
                        ScoredGoals = 11,
                        ConcededGoals = 2,
                        MatchesPlayed = 4,
                        Points = 10,
                },
                new Team
                {
                        Id = 2,
                        Name = "Chelsea",
                        Wins = 1,
                        Draws = 1,
                        Looses = 2,
                        ScoredGoals = 5,
                        ConcededGoals = 11,
                        MatchesPlayed = 4,
                        Points = 4,
                },
            };

            var leagueList = new List<League>()
            {
                new League
                {
                    Id = 1,
                    Name = "English Premier Division",
                    Teams = teamsList,
                },
                new League
                {
                    Id = 2,
                    Name = "Bundesliga",
                    Teams = teamsList,
                },
            };

            var leagueRepo = new Mock<IDeletableEntityRepository<League>>();
            leagueRepo.Setup(x => x.All()).Returns(leagueList.AsQueryable());

            var service = new StandingsService(leagueRepo.Object);

            var league = service.LeagueStandings("English Premier Division");

            var leagueName = league.Name;
            var teamId = league.Teams.Select(x => x.Id).FirstOrDefault();
            var teamName = league.Teams.Select(x => x.Name).FirstOrDefault();
            var teamWins = league.Teams.Select(x => x.Wins).FirstOrDefault();
            var teamDraws = league.Teams.Select(x => x.Draws).FirstOrDefault();
            var teamLooses = league.Teams.Select(x => x.Looses).FirstOrDefault();
            var teamScoredGoals = league.Teams.Select(x => x.ScoredGoals).FirstOrDefault();
            var teamConcededGoals = league.Teams.Select(x => x.ConcededGoals).FirstOrDefault();
            var teamPlayedMatches = league.Teams.Select(x => x.MatchesPlayed).FirstOrDefault();
            var teamPoints = league.Teams.Select(x => x.Points).FirstOrDefault();

            Assert.Equal("English Premier Division", leagueName);
            Assert.Equal(1, teamId);
            Assert.Equal("Arsenal", teamName);
            Assert.Equal(3, teamWins);
            Assert.Equal(1, teamDraws);
            Assert.Equal(0, teamLooses);
            Assert.Equal(11, teamScoredGoals);
            Assert.Equal(2, teamConcededGoals);
            Assert.Equal(4, teamPlayedMatches);
            Assert.Equal(10, teamPoints);

            leagueRepo.Verify(l => l.All(), Times.Once);
        }
    }
}
