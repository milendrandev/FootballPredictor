namespace FootballPredictor.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using Moq;
    using Xunit;

    using Match = FootballPredictor.Data.Models.Match;

    public class MatchesServiceTests
    {
        [Fact]
        public void GetAllMethodReturnCorrectDataSetProperties()
        {
            var list = new List<Match>
            {
                new Match
                {
                    Id = 1,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeGoals = 3,
                    AwayGoals = 1,
                    ResultType = FootballPredictor.Data.Models.Enums.BetType.Home,
                    GameweekId = 1,
                    LeagueId = 1,
                },
                new Match
                {
                     Id = 2,
                     HomeTeamId = 1,
                     AwayTeamId = 2,
                     HomeGoals = 3,
                     AwayGoals = 1,
                     ResultType = FootballPredictor.Data.Models.Enums.BetType.Home,
                     GameweekId = 1,
                     LeagueId = 1,
                },
                new Match
                {
                     Id = 3,
                     HomeTeamId = 1,
                     AwayTeamId = 2,
                     HomeGoals = 3,
                     AwayGoals = 1,
                     ResultType = FootballPredictor.Data.Models.Enums.BetType.Home,
                     GameweekId = 2,
                     LeagueId = 1,
                },
            }.AsQueryable<Match>();

            var leagues = new List<League>()
            {
                new League
                {
                    Id = 1,
                    Name = "English",
                    Country = "England",
                    Matches = list.ToList(),
                },
            }.AsQueryable<League>();

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

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();
            matchRepo.Setup(r => r.All()).Returns(list);

            var leagueRepo = new Mock<IDeletableEntityRepository<League>>();
            leagueRepo.Setup(r => r.All()).Returns(leagues);

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            teamRepo.Setup(x => x.All()).Returns(teamsList.AsQueryable());

            var playerRepo = new Mock<IDeletableEntityRepository<Player>>();
            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();

            var service = new MatchesService(matchRepo.Object, teamRepo.Object, leagueRepo.Object, playerRepo.Object, predictionRepo.Object);

            var leaguesList = service.GetAll(1);
            var matches = leaguesList.Select(m => m.Matches).FirstOrDefault();
            var league = leaguesList.FirstOrDefault();

            var leagueId = league.LeagueId;
            var leagueName = league.LeagueName;

            var matchId = league.Matches.Select(x => x.Id).FirstOrDefault();
            var homeGoals = league.Matches.Select(x => x.HomeGoals).FirstOrDefault();
            var awayGoals = league.Matches.Select(x => x.AwayGoals).FirstOrDefault();
            var gameWeekId = league.Matches.Select(x => x.GameweekId).FirstOrDefault();
            var homeName = league.Matches.Select(x => x.HomeName).FirstOrDefault();
            var awayName = league.Matches.Select(x => x.AwayName).FirstOrDefault();


            Assert.Equal(leaguesList.Count(), leagues.Count());
            Assert.Equal(matches.Count(), list.Where(m => m.GameweekId == 1).Count());
            Assert.Equal(1, leagueId);
            Assert.Equal("English", leagueName);
            leagueRepo.Verify(x => x.All(), Times.Once);

            Assert.Equal(1, matchId);
            Assert.Equal(3, homeGoals);
            Assert.Equal(1, awayGoals);
            Assert.Equal(1, gameWeekId);
            Assert.Equal("Real Madrid", homeName);
            Assert.Equal("Barcelona", awayName);
        }

        [Fact]
        public void GetAllMethodByUserReturnIsMatchPredicted()
        {
            var list = new List<Match>
            {
                new Match
                {
                    Id = 1,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeGoals = 3,
                    AwayGoals = 1,
                    ResultType = FootballPredictor.Data.Models.Enums.BetType.Home,
                    GameweekId = 1,
                    LeagueId = 1,
                },
                new Match
                {
                     Id = 2,
                     HomeTeamId = 1,
                     AwayTeamId = 2,
                     HomeGoals = 3,
                     AwayGoals = 1,
                     ResultType = FootballPredictor.Data.Models.Enums.BetType.Home,
                     GameweekId = 1,
                     LeagueId = 1,
                },
                new Match
                {
                     Id = 3,
                     HomeTeamId = 1,
                     AwayTeamId = 2,
                     HomeGoals = 3,
                     AwayGoals = 1,
                     ResultType = FootballPredictor.Data.Models.Enums.BetType.Home,
                     GameweekId = 2,
                     LeagueId = 1,
                },
            }.AsQueryable<Match>();

            var leagues = new List<League>()
            {
                new League
                {
                    Id = 1,
                    Name = "English",
                    Country = "England",
                    Matches = list.ToList(),
                },
            }.AsQueryable<League>();

            var user = new ApplicationUser
            {
                Id = "abc",
                UserName = "Milen",
            };

            var predictions = new List<Prediction>()
            {
                new Prediction
                {
                    Id = 1,
                    HomeTeamGoals = 2,
                    AwayTeamGoals = 1,
                    Bet = FootballPredictor.Data.Models.Enums.BetType.Home,
                    MatchId = 1,
                    UserId = user.Id,
                    Description = "dadadadadadadadadadadadada",
                    GameweekId = 1,
                },

                new Prediction
                {
                    Id = 2,
                    HomeTeamGoals = 2,
                    AwayTeamGoals = 1,
                    Bet = FootballPredictor.Data.Models.Enums.BetType.Home,
                    MatchId = 1,
                    UserId = "cfe",
                    Description = "dadadadadadadadadadadadada",
                    GameweekId = 1,
                },
            };

            user.Predictions.Add(predictions[0]);

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();
            matchRepo.Setup(r => r.All()).Returns(list);

            var leagueRepo = new Mock<IDeletableEntityRepository<League>>();
            leagueRepo.Setup(r => r.All()).Returns(leagues);
            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            var playerRepo = new Mock<IDeletableEntityRepository<Player>>();
            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();
            predictionRepo.Setup(r => r.All()).Returns(predictions.AsQueryable());

            var service = new MatchesService(matchRepo.Object, teamRepo.Object, leagueRepo.Object, playerRepo.Object, predictionRepo.Object);

            var leaguesModels = service.GetAll(user.Id, 1);

            var match = leaguesModels.Select(x => x.Matches).FirstOrDefault().FirstOrDefault();

            var pred = predictions[0];
            Assert.Equal(leaguesModels.Count(), leagues.Count());
            Assert.Equal(user.Id, pred.UserId);
            Assert.Equal(false, match.PredictionCreated);
            predictionRepo.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public void SimulateMethodWorkCorrectly()
        {
            var matchList = new List<Match>
            {
                new Match
                {
                    Id = 1,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeGoals = 3,
                    AwayGoals = 1,
                    ResultType = FootballPredictor.Data.Models.Enums.BetType.Home,
                    GameweekId = 1,
                    LeagueId = 1,
                },
                new Match
                {
                     Id = 2,
                     HomeTeamId = 1,
                     AwayTeamId = 2,
                     HomeGoals = 3,
                     AwayGoals = 1,
                     ResultType = FootballPredictor.Data.Models.Enums.BetType.Home,
                     GameweekId = 1,
                     LeagueId = 1,
                },
                new Match
                {
                     Id = 3,
                     HomeTeamId = 1,
                     AwayTeamId = 2,
                     HomeGoals = 3,
                     AwayGoals = 1,
                     ResultType = FootballPredictor.Data.Models.Enums.BetType.Home,
                     GameweekId = 2,
                     LeagueId = 1,
                },
            };

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

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();
            matchRepo.Setup(r => r.All()).Returns(matchList.AsQueryable());

            var leagueRepo = new Mock<IDeletableEntityRepository<League>>();

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            teamRepo.Setup(x => x.All()).Returns(teamsList.AsQueryable());

            var playerRepo = new Mock<IDeletableEntityRepository<Player>>();
            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();

            var service = new MatchesService(matchRepo.Object, teamRepo.Object, leagueRepo.Object, playerRepo.Object, predictionRepo.Object);
        }
    }
}
