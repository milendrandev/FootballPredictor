namespace FootballPredictor.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using Moq;
    using Xunit;

    using Match = FootballPredictor.Data.Models.Match;

    public class UsersServiceTests
    {
        [Fact]
        public void RankingsMethodReturnUsersAndSetPropertiesToViewModels()
        {
            var usersList = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    Id = "abc",
                    UserName = "Milen@abv.bg",
                    UserPoints = 50,
                },
                new ApplicationUser
                {
                    Id = "cde",
                    UserName = "Gosho@abv.bg",
                    UserPoints = 100,
                },
            };

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            userRepo.Setup(x => x.All()).Returns(usersList.AsQueryable());

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();
            var gameUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();
            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();

            var service = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameUserRepo.Object);

            var users = service.Rankings();

            Assert.Equal(usersList.Count, users.Count());
            userRepo.Verify(u => u.All(), Times.Once);

            var userId = users.Select(x => x.Id).FirstOrDefault();
            var username = users.Select(x => x.Username).FirstOrDefault();
            var userPoints = users.Select(x => x.UserPoints).FirstOrDefault();

            Assert.Equal("cde", userId);
            Assert.Equal("Gosho@abv.bg", username);
            Assert.Equal(100, userPoints);
        }

        [Fact]
        public void UserGameWeekPointsMethodReturnDataAndSetPropertiesInViewModel()
        {
            var gameWeekUserList = new List<GameweekUser>()
            {
                new GameweekUser
                {
                    UserId = "abc",
                    GameweekId = 1,
                    UserPoints = 20,
                },
            };

            var usersList = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    Id = "abc",
                    UserName = "Milen@abv.bg",
                    UserPoints = 50,
                    UserGameweeks = gameWeekUserList,
                },
                new ApplicationUser
                {
                    Id = "cde",
                    UserName = "Gosho@abv.bg",
                    UserPoints = 100,
                },
            };

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            userRepo.Setup(x => x.All()).Returns(usersList.AsQueryable());

            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();
            var gameUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();
            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();

            var service = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameUserRepo.Object);

            var user = service.UserGameweeksPoints("abc");
            var username = user.Username;
            var totalPoints = user.TotalPoints;
            var gameweekPoints = user.GameweekPoints.Select(x => x.GameweekPoints).FirstOrDefault();
            var gameWeekId = user.GameweekPoints.Select(x => x.Id).FirstOrDefault();

            Assert.Equal("Milen@abv.bg", username);
            Assert.Equal(50, totalPoints);
            Assert.Equal(20, gameweekPoints);
            Assert.Equal(1, gameWeekId);

            userRepo.Verify(u => u.All(), Times.Once);
        }

        [Fact]
        public async Task CreateUserInGameweekMethodAddProperly()
        {
            var list = new List<GameweekUser>();

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();

            var gameUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();
            gameUserRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            gameUserRepo.Setup(x => x.AddAsync(It.IsAny<GameweekUser>())).Callback(
                (GameweekUser user) => list.Add(user));

            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();

            var service = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameUserRepo.Object);

            await service.CreateUserInGameweek(1, "abc");
            await service.CreateUserInGameweek(1, "dfe");

            var actualUserId = list.Select(x => x.UserId).FirstOrDefault();
            var actualGameWeekId = list.Select(x => x.GameweekId).FirstOrDefault();

            Assert.Equal(2, list.Count);
            Assert.Equal("abc", actualUserId);
            Assert.Equal(1, actualGameWeekId);
        }

        [Fact]
        public async Task CreateUserInGameweekMethodDontAdd()
        {
            var list = new List<GameweekUser>()
            {
               new GameweekUser
               {
                   UserId = "abc",
                   GameweekId = 1,
               },
            };

            var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            var matchRepo = new Mock<IDeletableEntityRepository<Match>>();

            var gameUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();
            gameUserRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            gameUserRepo.Setup(x => x.AddAsync(It.IsAny<GameweekUser>())).Callback(
                (GameweekUser user) => list.Add(user));

            var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();

            var service = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameUserRepo.Object);

            await service.CreateUserInGameweek(1, "abc");

            gameUserRepo.Verify(g => g.AddAsync(list[0]), Times.Never);
        }

      // [Fact]
      // public void AddPointsToUserMethodAddPoints()
      // {
      //
      //
      //     var userRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
      //
      //     var matchRepo = new Mock<IDeletableEntityRepository<Match>>();
      //
      //     var gameUserRepo = new Mock<IDeletableEntityRepository<GameweekUser>>();
      //     gameUserRepo.Setup(x => x.All()).Returns(list.AsQueryable());
      //
      //     var predictionRepo = new Mock<IDeletableEntityRepository<Prediction>>();
      //
      //     var service = new UsersService(userRepo.Object, matchRepo.Object, predictionRepo.Object, gameUserRepo.Object);
      //
      // }
    } //
}
