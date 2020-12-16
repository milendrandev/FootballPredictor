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

    using Match = FootballPredictor.Data.Models.Match;

    public class TeamsServiceTests
    {
        [Fact]
        public void GetSquadReturnPlayersToChosenTeamAndSetPropertiesCorectly()
        {
            var playersList = new List<Player>()
            {
                new Player
                {
                  ShortName = "L.Messi",
                  ScoredGoals = 10,
                  MatchesPlayed = 1,
                  Age = 33,
                  DateOfBirth = DateTime.Parse("12/12/1986"),
                  HeightCm = 166,
                  WeightKg = 70,
                  Nationality = "Argentina",
                  TeamNumber = 10,
                  TeamId = 1,
                },

                new Player
                {
                    ShortName = "C.Ronaldo",
                    ScoredGoals = 11,
                    MatchesPlayed = 2,
                    Age = 35,
                    DateOfBirth = DateTime.Parse("12/12/1984"),
                    HeightCm = 186,
                    WeightKg = 80,
                    Nationality = "Portugal",
                    TeamNumber = 7,
                    TeamId = 1,
                },
            };

            var teamsList = new List<Team>()
            {
                new Team
                {
                    Id = 1,
                    Name = "Real Madrid",
                    Players = playersList,
                },
                new Team
                {
                    Id = 2,
                    Name = "Barcelona",
                },
            };

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            teamRepo.Setup(x => x.All()).Returns(teamsList.AsQueryable());

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();

            var service = new TeamsService(teamRepo.Object, matchRepo.Object);

            var team = service.GetSquad(1);

            var playerFirstName = team.Players.Select(x => x.ShortName).FirstOrDefault();
            var playerSquadNumber = team.Players.Select(x => x.SquadNumber).FirstOrDefault();
            var scoredGoals = team.Players.Select(x => x.ScoredGoals).FirstOrDefault();
            var age = team.Players.Select(x => x.Age).FirstOrDefault();
            var matchesPlayed = team.Players.Select(x => x.MatchesPlayed).FirstOrDefault();
            var weight = team.Players.Select(x => x.WeightKg).FirstOrDefault();
            var height = team.Players.Select(x => x.HeightCm).FirstOrDefault();
            var dateOfBirth = team.Players.Select(x => x.DateOfBirth).FirstOrDefault();
            var nationality = team.Players.Select(x => x.Nationality).FirstOrDefault();

            Assert.Equal("Real Madrid", team.TeamName);
            Assert.Equal(2, team.Players.Count());

            Assert.Equal(7, playerSquadNumber);
            Assert.Equal("C.Ronaldo", playerFirstName);
            Assert.Equal(11, scoredGoals);
            Assert.Equal(35, age);
            Assert.Equal(2, matchesPlayed);
            Assert.Equal(80, weight);
            Assert.Equal(186, height);
            Assert.Equal(DateTime.Parse("12/12/1984"), dateOfBirth);
            Assert.Equal("Portugal", nationality);
        }

        [Fact]
        public void TeamDetailsReturnTeamMatchesAndSetProperties()
        {
            var teamsList = new List<Team>()
            {
                new Team
                {
                    Id = 1,
                    Name = "Real Madrid",
                },
                new Team
                {
                    Id = 2,
                    Name = "Barcelona",
                },
            };

            var matchList = new List<Match>()
            {
                new Match
                {
                    HomeGoals = 1,
                    AwayGoals = 0,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    GameweekId = 1,

                },
                new Match()
                {
                    HomeGoals = 3,
                    AwayGoals = 3,
                    HomeTeamId = 4,
                    AwayTeamId = 5,
                    GameweekId = 2,
                },
            };

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            teamRepo.Setup(x => x.All()).Returns(teamsList.AsQueryable());

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();
            matchRepo.Setup(x => x.All()).Returns(matchList.AsQueryable());

            var service = new TeamsService(teamRepo.Object, matchRepo.Object);

            var team = service.TeamDetails(1);

            var homeTeamName = team.Matches.Select(x => x.HomeName).FirstOrDefault();
            var awayTeamName = team.Matches.Select(x => x.AwayName).FirstOrDefault();
            var homeGoals = team.Matches.Select(x => x.HomeGoals).FirstOrDefault();
            var awayGoals = team.Matches.Select(x => x.AwayGoals).FirstOrDefault();
            var gameWeekId = team.Matches.Select(x => x.GameweekId).FirstOrDefault();

            Assert.Equal(1, team.Id);
            Assert.Equal("Real Madrid", team.Name);
            Assert.Equal(1, team.Matches.Count());

            Assert.Equal(1, homeGoals);
            Assert.Equal(0, awayGoals);
            Assert.Equal("Real Madrid", homeTeamName);
            Assert.Equal("Barcelona", awayTeamName);
            Assert.Equal(1, gameWeekId);

            matchRepo.Verify(m => m.All(), Times.Once);
        }
    }
}
