namespace FootballPredictor.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Data.Models.Enums;
    using FootballPredictor.Web.ViewModels.Predictions;
    using Moq;
    using Xunit;

    using Match = FootballPredictor.Data.Models.Match;

    public class PredictionsServiceTests
    {
        [Fact]
        public async Task CreateAsyncMethodAddPrediction()
        {
            var predictionList = new List<Prediction>();

            var matchesList = new List<Match>()
            {
                new Match
                {
                    Id = 1,
                    GameweekId = 3,
                },
            };

            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();
            predictionRepo.Setup(x => x.All()).Returns(predictionList.AsQueryable());
            predictionRepo.Setup(x => x.AddAsync(It.IsAny<Prediction>())).Callback(
                (Prediction prediction) => predictionList.Add(prediction));

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();
            matchRepo.Setup(x => x.All()).Returns(matchesList.AsQueryable());

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            var gameWeekUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();

            var usersService = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameWeekUserRepo.Object);
            var service = new PredictionsService(predictionRepo.Object, userRepo.Object, matchRepo.Object, teamRepo.Object, usersService);

            var prediction = new Prediction
            {
                HomeTeamGoals = 2,
                AwayTeamGoals = 3,
                Description = "dadadadadadadadadadadadadadadadadada",
                UserId = "abc",
                MatchId = 1,
            };

            await service.CreateAsync(prediction.MatchId, prediction.HomeTeamGoals, prediction.AwayTeamGoals, prediction.Description, prediction.UserId);

            var mockPrediction = predictionList.FirstOrDefault();

            Assert.Equal(1, predictionList.Count);
            Assert.Equal(prediction.HomeTeamGoals, mockPrediction.HomeTeamGoals);
            Assert.Equal(prediction.AwayTeamGoals, mockPrediction.AwayTeamGoals);
            Assert.Equal(prediction.Description, mockPrediction.Description);
            Assert.Equal(prediction.UserId, mockPrediction.UserId);
            Assert.Equal(prediction.MatchId, mockPrediction.MatchId);
            Assert.Equal(3, mockPrediction.GameweekId);
            Assert.Equal(BetType.Away, mockPrediction.Bet);
        }

        [Fact]
        public async Task CreateAsyncMethodDontAddPredictionIfPredictionsAreMoreThanLimit()
        {
            var predictionList = new List<Prediction>()
            {
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
                new Prediction
                {
                    UserId = "abc",
                    GameweekId = 3,
                },
            };

            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();
            predictionRepo.Setup(x => x.All()).Returns(predictionList.AsQueryable());
            predictionRepo.Setup(x => x.AddAsync(It.IsAny<Prediction>())).Callback(
                (Prediction prediction) => predictionList.Add(prediction));

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            var gameWeekUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();

            var usersService = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameWeekUserRepo.Object);
            var service = new PredictionsService(predictionRepo.Object, userRepo.Object, matchRepo.Object, teamRepo.Object, usersService);

            await service.CreateAsync(1, 2, 1, "dadadadadadadadadadada", "abc");

            Assert.Equal(15, predictionList.Count);
            predictionRepo.Verify(m => m.AddAsync(predictionList[0]), Times.Never);
        }

        [Fact]
        public async Task CreateAsyncMethodDontAddPredictionIfPredictionIsCreated()
        {
            var prediction = new Prediction
            {
                HomeTeamGoals = 2,
                AwayTeamGoals = 3,
                Description = "dadadadadadadadadadadadadadadadadada",
                UserId = "abc",
                MatchId = 1,
            };

            var matchesList = new List<Match>()
            {
                new Match
                {
                    Id = 1,
                    GameweekId = 3,
                },
            };

            var predictionList = new List<Prediction>();

            var usersList = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    Id = "abc",
                    Predictions = predictionList,
                },
            };

            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();
            predictionRepo.Setup(x => x.All()).Returns(predictionList.AsQueryable());
            predictionRepo.Setup(x => x.AddAsync(It.IsAny<Prediction>())).Callback(
                (Prediction prediction) => predictionList.Add(prediction));

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            userRepo.Setup(x => x.All()).Returns(usersList.AsQueryable());

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();
            matchRepo.Setup(x => x.All()).Returns(matchesList.AsQueryable());

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            var gameWeekUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();

            var usersService = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameWeekUserRepo.Object);

            var service = new PredictionsService(predictionRepo.Object, userRepo.Object, matchRepo.Object, teamRepo.Object, usersService);

            await service.CreateAsync(prediction.MatchId, prediction.HomeTeamGoals, prediction.AwayTeamGoals, prediction.Description, prediction.UserId);
            await service.CreateAsync(prediction.MatchId, prediction.HomeTeamGoals, prediction.AwayTeamGoals, prediction.Description, prediction.UserId);

            Assert.Equal(1, predictionList.Count);
        }

        [Fact]
        public async Task CreateAsyncMethodDontAddPredictionIfGameWeekIsPassed()
        {
            var prediction = new Prediction
            {
                HomeTeamGoals = 2,
                AwayTeamGoals = 3,
                Description = "dadadadadadadadadadadadadadadadadada",
                UserId = "abc",
                MatchId = 1,
            };

            var matchesList = new List<Match>()
            {
                new Match
                {
                    Id = 1,
                    GameweekId = 2,
                },
            };

            var predictionList = new List<Prediction>();

            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();
            predictionRepo.Setup(x => x.All()).Returns(predictionList.AsQueryable());
            predictionRepo.Setup(x => x.AddAsync(It.IsAny<Prediction>())).Callback(
                (Prediction prediction) => predictionList.Add(prediction));

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();
            matchRepo.Setup(x => x.All()).Returns(matchesList.AsQueryable());

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            var gameWeekUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();

            var usersService = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameWeekUserRepo.Object);

            var service = new PredictionsService(predictionRepo.Object, userRepo.Object, matchRepo.Object, teamRepo.Object, usersService);

            await service.CreateAsync(prediction.MatchId, prediction.HomeTeamGoals, prediction.AwayTeamGoals, prediction.Description, prediction.UserId);

            Assert.Equal(0, predictionList.Count);
        }

        [Fact]
        public void AllMethodReturnDataAndProperties()
        {
            var predictionList = new List<Prediction>()
            {
                new Prediction
                {
                    Id = 2,
                    HomeTeamGoals = 2,
                    AwayTeamGoals = 3,
                    Description = "dadadadadadadadadadadadadadadadadada",
                    UserId = "abc",
                    MatchId = 1,
                    GameweekId = 3,
                },
                new Prediction
                {
                    Id = 2,
                    HomeTeamGoals = 4,
                    AwayTeamGoals = 1,
                    Description = "fafafaffafafafafafafafafafaffa",
                    UserId = "def",
                    MatchId = 2,
                    GameweekId = 3,
                },
            };

            var matchList = new List<Match>()
            {
                new Match
                {
                    Id = 1,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                },
                new Match
                {
                    Id = 2,
                    HomeTeamId = 2,
                    AwayTeamId = 3,
                },
            };

            var teamsList = new List<Team>()
            {
                new Team
                {
                    Id = 1,
                    Name = "Arsenal",
                },
                new Team
                {
                    Id = 2,
                    Name = "Chelsea",
                },
                new Team
                {
                    Id = 3,
                    Name = "Liverpool",
                },
            };

            var userList = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    Id = "abc",
                    UserName = "Milen",
                },
            };

            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();
            predictionRepo.Setup(x => x.All()).Returns(predictionList.AsQueryable());

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            userRepo.Setup(x => x.All()).Returns(userList.AsQueryable());

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();
            matchRepo.Setup(x => x.All()).Returns(matchList.AsQueryable());

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            teamRepo.Setup(c => c.All()).Returns(teamsList.AsQueryable());

            var gameWeekUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();

            var usersService = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameWeekUserRepo.Object);

            var service = new PredictionsService(predictionRepo.Object, userRepo.Object, matchRepo.Object, teamRepo.Object, usersService);

            var predictions = service.All(1, 2);
            var predictionId = predictions.Select(x => x.Id).FirstOrDefault();
            var homeTeam = predictions.Select(x => x.HomeTeamName).FirstOrDefault();
            var awayTeam = predictions.Select(x => x.AwayTeamName).FirstOrDefault();
            var homeGoals = predictions.Select(x => x.HomeTeamGoals).FirstOrDefault();
            var awayGoals = predictions.Select(x => x.AwayTeamGoals).FirstOrDefault();
            var userId = predictions.Select(x => x.UserId).FirstOrDefault();
            var username = predictions.Select(x => x.Username).FirstOrDefault();
            var description = predictions.Select(x => x.Description).FirstOrDefault();
            var gameWeekId = predictions.Select(x => x.GameweekId).FirstOrDefault();

            Assert.Equal(predictionList.Count, predictions.Count());
            Assert.Equal(2, predictionId);
            Assert.Equal("Arsenal", homeTeam);
            Assert.Equal("Chelsea", awayTeam);
            Assert.Equal(2, homeGoals);
            Assert.Equal(3, awayGoals);
            Assert.Equal("abc", userId);
            Assert.Equal("Milen", username);
            Assert.Equal(3, gameWeekId);
            Assert.Equal("dadadadadadadadadadadadadadadadadada", description);
        }

        [Fact]
        public void PredictionsByUserMethodReturnDataAndProperties()
        {
            var predictionList = new List<Prediction>()
            {
                new Prediction
                {
                    Id = 2,
                    HomeTeamGoals = 2,
                    AwayTeamGoals = 3,
                    Description = "dadadadadadadadadadadadadadadadadada",
                    UserId = "abc",
                    MatchId = 1,
                    GameweekId = 3,
                },
                new Prediction
                {
                    Id = 2,
                    HomeTeamGoals = 4,
                    AwayTeamGoals = 1,
                    Description = "fafafaffafafafafafafafafafaffa",
                    UserId = "def",
                    MatchId = 2,
                    GameweekId = 3,
                },
            };

            var matchList = new List<Match>()
            {
                new Match
                {
                    Id = 1,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                },
                new Match
                {
                    Id = 2,
                    HomeTeamId = 2,
                    AwayTeamId = 3,
                },
            };

            var teamsList = new List<Team>()
            {
                new Team
                {
                    Id = 1,
                    Name = "Arsenal",
                },
                new Team
                {
                    Id = 2,
                    Name = "Chelsea",
                },
                new Team
                {
                    Id = 3,
                    Name = "Liverpool",
                },
            };

            var userList = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    Id = "abc",
                    UserName = "Milen",
                },
            };

            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();
            predictionRepo.Setup(x => x.All()).Returns(predictionList.AsQueryable());

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            userRepo.Setup(x => x.All()).Returns(userList.AsQueryable());

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();
            matchRepo.Setup(x => x.All()).Returns(matchList.AsQueryable());

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            teamRepo.Setup(c => c.All()).Returns(teamsList.AsQueryable());

            var gameWeekUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();

            var usersService = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameWeekUserRepo.Object);

            var service = new PredictionsService(predictionRepo.Object, userRepo.Object, matchRepo.Object, teamRepo.Object, usersService);

            var predictions = service.PredictionsByUser("abc",1, 2);
            var predictionId = predictions.Select(x => x.Id).FirstOrDefault();
            var homeTeam = predictions.Select(x => x.HomeTeamName).FirstOrDefault();
            var awayTeam = predictions.Select(x => x.AwayTeamName).FirstOrDefault();
            var homeGoals = predictions.Select(x => x.HomeTeamGoals).FirstOrDefault();
            var awayGoals = predictions.Select(x => x.AwayTeamGoals).FirstOrDefault();
            var userId = predictions.Select(x => x.UserId).FirstOrDefault();
            var username = predictions.Select(x => x.Username).FirstOrDefault();
            var description = predictions.Select(x => x.Description).FirstOrDefault();
            var gameWeekId = predictions.Select(x => x.GameweekId).FirstOrDefault();

            Assert.Equal(1, predictions.Count());
            Assert.Equal(2, predictionId);
            Assert.Equal("Arsenal", homeTeam);
            Assert.Equal("Chelsea", awayTeam);
            Assert.Equal(2, homeGoals);
            Assert.Equal(3, awayGoals);
            Assert.Equal("abc", userId);
            Assert.Equal("Milen", username);
            Assert.Equal(3, gameWeekId);
            Assert.Equal("dadadadadadadadadadadadadadadadadada", description);
        }

        [Fact]
        public void PredictionsCountMethodReturnCorrectCount()
        {
            var predictionList = new List<Prediction>()
            {
                new Prediction
                {
                    Id = 2,
                    HomeTeamGoals = 2,
                    AwayTeamGoals = 3,
                    Description = "dadadadadadadadadadadadadadadadadada",
                    UserId = "abc",
                    MatchId = 1,
                    GameweekId = 3,
                },
                new Prediction
                {
                    Id = 2,
                    HomeTeamGoals = 4,
                    AwayTeamGoals = 1,
                    Description = "fafafaffafafafafafafafafafaffa",
                    UserId = "def",
                    MatchId = 2,
                    GameweekId = 3,
                },
            };

            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();
            predictionRepo.Setup(x => x.All()).Returns(predictionList.AsQueryable());

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            var gameWeekUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();

            var usersService = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameWeekUserRepo.Object);
            var service = new PredictionsService(predictionRepo.Object, userRepo.Object, matchRepo.Object, teamRepo.Object, usersService);

            var predictions = service.PredictionsCount();

            Assert.Equal(predictionList.Count, predictions);
        }

        [Fact]
        public void PredictionsByUserCountMethodReturnTheCount()
        {
            var predictionList = new List<Prediction>()
            {
                new Prediction
                {
                    Id = 2,
                    HomeTeamGoals = 2,
                    AwayTeamGoals = 3,
                    Description = "dadadadadadadadadadadadadadadadadada",
                    UserId = "abc",
                    MatchId = 1,
                    GameweekId = 3,
                },
                new Prediction
                {
                    Id = 2,
                    HomeTeamGoals = 4,
                    AwayTeamGoals = 1,
                    Description = "fafafaffafafafafafafafafafaffa",
                    UserId = "def",
                    MatchId = 2,
                    GameweekId = 3,
                },
            };

            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();
            predictionRepo.Setup(x => x.All()).Returns(predictionList.AsQueryable());

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            var gameWeekUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();

            var usersService = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameWeekUserRepo.Object);
            var service = new PredictionsService(predictionRepo.Object, userRepo.Object, matchRepo.Object, teamRepo.Object, usersService);

            var predictions = service.PredictionsByUserCount("abc");

            Assert.Equal(1, predictions);
        }

        [Fact]
        public void PredictionByIdMethodReturnPredictionAndProperties()
        {
            var predictionList = new List<Prediction>()
            {
                new Prediction
                {
                    Id = 2,
                    HomeTeamGoals = 2,
                    AwayTeamGoals = 3,
                    Description = "dadadadadadadadadadadadadadadadadada",
                    UserId = "abc",
                    MatchId = 1,
                    GameweekId = 3,
                },
                new Prediction
                {
                    Id = 1,
                    HomeTeamGoals = 4,
                    AwayTeamGoals = 1,
                    Description = "fafafaffafafafafafafafafafaffa",
                    UserId = "def",
                    MatchId = 2,
                    GameweekId = 3,
                },
            };

            var matchList = new List<Match>()
            {
                new Match
                {
                    Id = 1,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                },
                new Match
                {
                    Id = 2,
                    HomeTeamId = 2,
                    AwayTeamId = 3,
                },
            };

            var teamsList = new List<Team>()
            {
                new Team
                {
                    Id = 1,
                    Name = "Arsenal",
                },
                new Team
                {
                    Id = 2,
                    Name = "Chelsea",
                },
                new Team
                {
                    Id = 3,
                    Name = "Liverpool",
                },
            };

            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();
            predictionRepo.Setup(x => x.All()).Returns(predictionList.AsQueryable());

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();
            matchRepo.Setup(x => x.All()).Returns(matchList.AsQueryable());

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();
            teamRepo.Setup(c => c.All()).Returns(teamsList.AsQueryable());

            var gameWeekUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();

            var usersService = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameWeekUserRepo.Object);

            var service = new PredictionsService(predictionRepo.Object, userRepo.Object, matchRepo.Object, teamRepo.Object, usersService);

            var prediction = service.PredictionById(2);

            Assert.Equal(2, prediction.Id);
            Assert.Equal(2, prediction.HomeGoals);
            Assert.Equal(3, prediction.AwayGoals);
            Assert.Equal("Arsenal", prediction.HomeTeamName);
            Assert.Equal("Chelsea", prediction.AwayTeamName);
            Assert.Equal("dadadadadadadadadadadadadadadadadada", prediction.Description);
        }

        [Fact]
        public async Task DeleteAsyncMethodDeletePrediction()
        {
            var predictionList = new List<Prediction>()
            {
                new Prediction
                {
                    Id = 2,
                    HomeTeamGoals = 2,
                    AwayTeamGoals = 3,
                    Description = "dadadadadadadadadadadadadadadadadada",
                    UserId = "abc",
                    MatchId = 1,
                    GameweekId = 3,
                },
                new Prediction
                {
                    Id = 1,
                    HomeTeamGoals = 4,
                    AwayTeamGoals = 1,
                    Description = "fafafaffafafafafafafafafafaffa",
                    UserId = "def",
                    MatchId = 2,
                    GameweekId = 3,
                },
            };

            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();
            predictionRepo.Setup(x => x.All()).Returns(predictionList.AsQueryable());
            predictionRepo.Setup(x => x.Delete(It.IsAny<Prediction>())).Callback(
                (Prediction prediction) => predictionList.Remove(prediction));

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();

            var gameWeekUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();

            var usersService = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameWeekUserRepo.Object);

            var service = new PredictionsService(predictionRepo.Object, userRepo.Object, matchRepo.Object, teamRepo.Object, usersService);

            await service.DeleteAsync(1, "abc");

            Assert.Equal(1, predictionList.Count);
        }

        [Fact]
        public async Task EditAsyncMethodEditPrediction()
        {
            var predictionList = new List<Prediction>()
            {
                new Prediction
                {
                    Id = 2,
                    HomeTeamGoals = 2,
                    AwayTeamGoals = 3,
                    Description = "dadadadadadadadadadadadadadadadadada",
                    UserId = "abc",
                    MatchId = 1,
                    GameweekId = 3,
                },
                new Prediction
                {
                    Id = 1,
                    HomeTeamGoals = 4,
                    AwayTeamGoals = 1,
                    Description = "fafafaffafafafafafafafafafaffa",
                    UserId = "def",
                    MatchId = 2,
                    GameweekId = 3,
                },
            };

            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();
            predictionRepo.Setup(x => x.All()).Returns(predictionList.AsQueryable());

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();

            var teamRepo = new Mock<IDeletableEntityRepository<Team>>();

            var gameWeekUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();

            var usersService = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameWeekUserRepo.Object);

            var service = new PredictionsService(predictionRepo.Object, userRepo.Object, matchRepo.Object, teamRepo.Object, usersService);

            var model = new CreateViewModel
            {
                HomeGoals = 0,
                AwayGoals = 0,
                Description = "ne znam veche kakvo da pisha na towa opisanie",
            };

            await service.EditAsync(2, model);

            var prediction = predictionList.First();
            var homeGoals = prediction.HomeTeamGoals;
            var awayGoals = prediction.AwayTeamGoals;
            var description = prediction.Description;
            var bet = prediction.Bet;

            Assert.Equal(0, homeGoals);
            Assert.Equal(0, awayGoals);
            Assert.Equal("ne znam veche kakvo da pisha na towa opisanie", description);
            Assert.Equal(BetType.Draw, bet);
        }
    }
}
