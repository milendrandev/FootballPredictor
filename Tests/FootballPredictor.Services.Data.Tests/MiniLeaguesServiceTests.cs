namespace FootballPredictor.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    using FootballPredictor.Data.Common.Models;
    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Web.ViewModels.MiniLigues;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using Xunit;

    public class MiniLeaguesServiceTests
    {
        [Fact]
        public void AllMethodReturnMiniLigues()
        {
            var miniLeagueList = new List<MiniLigue>()
            {
                new MiniLigue
                {
                   Id = "abc",
                   Name = "moqtaLiga",
                },
                new MiniLigue
                {
                    Id = "1234",
                    Name = "AmoqtaLiga",
                },
            };

            var miniLeagueRepo = new Mock<IDeletableEntityRepository<MiniLigue>>();
            miniLeagueRepo.Setup(x => x.All()).Returns(miniLeagueList.AsQueryable());

            var miniUserRepo = new Mock<IDeletableEntityRepository<MiniLigueUser>>();

            var service = new MiniLeaguesService(miniLeagueRepo.Object, miniUserRepo.Object);

            var leagues = service.All();
            var leagueId = leagues.Select(x => x.Id).FirstOrDefault();
            var name = leagues.Select(x => x.Name).FirstOrDefault();
            var members = leagues.Select(x => x.Members).FirstOrDefault();

            Assert.Equal(leagues.Count(), miniLeagueList.Count);
            Assert.Equal("1234", leagueId);
            Assert.Equal("AmoqtaLiga", name);
            Assert.Equal(0, members);
        }

        [Fact]
        public async Task CreateAsyncMethodAddMiniLeague()
        {
            var list = new List<MiniLigue>();

            var miniLeagueRepo = new Mock<IDeletableEntityRepository<MiniLigue>>();
            miniLeagueRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            miniLeagueRepo.Setup(x => x.AddAsync(It.IsAny<MiniLigue>())).Callback(
                (MiniLigue league) => list.Add(league));

            var miniUserRepo = new Mock<IDeletableEntityRepository<MiniLigueUser>>();

            var service = new MiniLeaguesService(miniLeagueRepo.Object, miniUserRepo.Object);

            var model = new CreateInputModel
            {
                Name = "moqtaLiga",
                Password = "1234",
            };

            await service.CreateAsync(model, "abc");

            var league = list.First();
            var name = league.Name;
            var password = league.Password;
            var creatorId = league.CreatorId;

            Assert.Equal(1, list.Count);
            Assert.Equal(ComputeHash(model.Password), password);
            Assert.Equal(model.Name, name);
            Assert.Equal("abc", creatorId);
        }

        [Fact]
        public void DashboardMethodReturnDataCorrectly()
        {
            var usersList = new List<MiniLigueUser>()
            {
                new MiniLigueUser
                {
                    User = new ApplicationUser
                    {
                        Id = "aaaaa",
                        UserName = "Milen",
                        UserPoints = 50,
                    },
                },
                new MiniLigueUser
                {
                    User = new ApplicationUser
                    {
                        Id = "bbbbb",
                        UserName = "Georgi",
                        UserPoints = 20,
                    },
                },
            };

            var miniLeagueList = new List<MiniLigue>()
            {
                new MiniLigue
                {
                   Id = "abc",
                   Name = "moqtaLiga",
                   CreatorId = "aaaaa",
                   Users = usersList,
                },
                new MiniLigue
                {
                    Id = "1234",
                    Name = "AmoqtaLiga",
                    CreatorId = "bbbbb",
                },
            };

            var miniLeagueRepo = new Mock<IDeletableEntityRepository<MiniLigue>>();
            miniLeagueRepo.Setup(x => x.All()).Returns(miniLeagueList.AsQueryable());

            var miniUserRepo = new Mock<IDeletableEntityRepository<MiniLigueUser>>();

            var service = new MiniLeaguesService(miniLeagueRepo.Object, miniUserRepo.Object);

            var miniLegue = service.Dashboard("abc");
            var name = miniLegue.Name;

            var creatorId = miniLegue.CreatorId;
            var users = miniLegue.Users;
            var usersCount = users.Count();

            var userId = users.Select(x => x.Id).FirstOrDefault();
            var username = users.Select(x => x.Username).FirstOrDefault();
            var points = users.Select(x => x.UserPoints).FirstOrDefault();

            Assert.Equal("moqtaLiga", name);

            Assert.Equal("aaaaa", creatorId);
            Assert.Equal(2, usersCount);
            Assert.Equal("aaaaa", userId);
            Assert.Equal("Milen", username);
            Assert.Equal(50, points);

        }

        [Fact]
        public void IsAMemberMethodReturnFalse()
        {
            var list = new List<MiniLigueUser>()
            {
               new MiniLigueUser
               {
                   MiniLigueId = "1234",
                   UserId = "dfe",
               },
            };

            var miniLeagueRepo = new Mock<IDeletableEntityRepository<MiniLigue>>();

            var miniUserRepo = new Mock<IDeletableEntityRepository<MiniLigueUser>>();
            miniUserRepo.Setup(x => x.All()).Returns(list.AsQueryable());

            var service = new MiniLeaguesService(miniLeagueRepo.Object, miniUserRepo.Object);

            var result = service.IsAMember("1234","abc");

            Assert.False(result);
        }

        [Fact]
        public void IsAMemberMethodReturnTrue()
        {
            var list = new List<MiniLigueUser>()
            {
               new MiniLigueUser
               {
                   MiniLigueId = "1234",
                   UserId = "dfe",
               },
            };

            var miniLeagueRepo = new Mock<IDeletableEntityRepository<MiniLigue>>();

            var miniUserRepo = new Mock<IDeletableEntityRepository<MiniLigueUser>>();
            miniUserRepo.Setup(x => x.All()).Returns(list.AsQueryable());

            var service = new MiniLeaguesService(miniLeagueRepo.Object, miniUserRepo.Object);

            var result = service.IsAMember("1234", "dfe");

            Assert.True(result);
        }

        [Fact]
        public void IsCorrectPasswordReturnFalse()
        {
            var miniLegueList = new List<MiniLigue>()
            {
                new MiniLigue
                {
                    Id = "aaaaa",
                    Password = ComputeHash("1234"),
                },
            };

            var miniLeagueRepo = new Mock<IDeletableEntityRepository<MiniLigue>>();
            miniLeagueRepo.Setup(x => x.All()).Returns(miniLegueList.AsQueryable());

            var miniUserRepo = new Mock<IDeletableEntityRepository<MiniLigueUser>>();

            var service = new MiniLeaguesService(miniLeagueRepo.Object, miniUserRepo.Object);

            var result = service.IsCorrectPassword("aaaaa", "0000");

            Assert.False(result);
        }

        [Fact]
        public void IsCorrectPasswordReturnTrue()
        {
            var miniLegueList = new List<MiniLigue>()
            {
                new MiniLigue
                {
                    Id = "aaaaa",
                    Password = ComputeHash("1234"),
                },
            };

            var miniLeagueRepo = new Mock<IDeletableEntityRepository<MiniLigue>>();
            miniLeagueRepo.Setup(x => x.All()).Returns(miniLegueList.AsQueryable());

            var miniUserRepo = new Mock<IDeletableEntityRepository<MiniLigueUser>>();

            var service = new MiniLeaguesService(miniLeagueRepo.Object, miniUserRepo.Object);

            var result = service.IsCorrectPassword("aaaaa", "1234");

            Assert.True(result);
        }

        [Fact]
        public void MiniLegueNameMethodReturneTheName()
        {
            var miniLegueList = new List<MiniLigue>()
            {
                new MiniLigue
                {
                    Id = "aaaaa",
                    Name = "Milen",
                    Password = ComputeHash("1234"),
                },
            };

            var miniLeagueRepo = new Mock<IDeletableEntityRepository<MiniLigue>>();
            miniLeagueRepo.Setup(x => x.All()).Returns(miniLegueList.AsQueryable());

            var miniUserRepo = new Mock<IDeletableEntityRepository<MiniLigueUser>>();

            var service = new MiniLeaguesService(miniLeagueRepo.Object, miniUserRepo.Object);

            var name = service.MiniLigueName("aaaaa");

            Assert.Equal("Milen", name);
        }

        [Fact]
        public async Task JoinMethodAddMemberToMiniLegue()
        {
            var miniLegueList = new List<MiniLigue>()
            {
            };

            var miniLegueUsersList = new List<MiniLigueUser>();

            var miniLeagueRepo = new Mock<IDeletableEntityRepository<MiniLigue>>();
            miniLeagueRepo.Setup(x => x.All()).Returns(miniLegueList.AsQueryable());

            var miniUserRepo = new Mock<IDeletableEntityRepository<MiniLigueUser>>();
            miniUserRepo.Setup(x => x.AddAsync(It.IsAny<MiniLigueUser>())).Callback(
                (MiniLigueUser league) => miniLegueUsersList.Add(league));

            var service = new MiniLeaguesService(miniLeagueRepo.Object, miniUserRepo.Object);

            var model = new JoinViewModel
            {
                Id = "aaaaa",
            };

            await service.Join(model, "Milen");

            Assert.Equal(1, miniLegueUsersList.Count);
        }

        [Fact]
        public async Task CreateMiniLegueUserMethodAddCorrectly()
        {
            var miniLegueList = new List<MiniLigue>()
            {
            };

            var miniLegueUsersList = new List<MiniLigueUser>();

            var miniLeagueRepo = new Mock<IDeletableEntityRepository<MiniLigue>>();
            miniLeagueRepo.Setup(x => x.All()).Returns(miniLegueList.AsQueryable());

            var miniUserRepo = new Mock<IDeletableEntityRepository<MiniLigueUser>>();
            miniUserRepo.Setup(x => x.AddAsync(It.IsAny<MiniLigueUser>())).Callback(
                (MiniLigueUser league) => miniLegueUsersList.Add(league));

            var service = new MiniLeaguesService(miniLeagueRepo.Object, miniUserRepo.Object);

            var model = new JoinViewModel
            {
                Id = "aaaaa",
            };

            await service.(model, "Milen");

            Assert.Equal(1, miniLegueUsersList.Count);
        }

        [Fact]
        public async Task RemoveAsyncMethodRemoveMember()
        {
            var miniLegueUserList = new List<MiniLigueUser>()
            {
                new MiniLigueUser
                {
                    MiniLigueId = "aaaaa",
                    UserId = "abc",
                },
            };

            var miniLegueList = new List<MiniLigue>()
            {
                new MiniLigue
                {
                    Id = "aaaaa",
                    Name = "Milen",
                    Password = ComputeHash("1234"),
                    CreatorId = "Milen",
                    Users = miniLegueUserList,
                },
            };

            var miniLegueRepo = new Mock<IDeletableEntityRepository<MiniLigue>>();
            miniLegueRepo.Setup(x => x.All()).Returns(miniLegueList.AsQueryable());

            var miniLegueUserRepo = new Mock<IDeletableEntityRepository<MiniLigueUser>>();
            miniLegueUserRepo.Setup(x => x.All()).Returns(miniLegueUserList.AsQueryable());
            miniLegueUserRepo.Setup(x => x.Delete(It.IsAny<MiniLigueUser>())).Callback(
                (MiniLigueUser user) => miniLegueUserList.Remove(user));

            var service = new MiniLeaguesService(miniLegueRepo.Object, miniLegueUserRepo.Object);

            await service.RemoveAsync("abc", "Milen");

            var usersCount = miniLegueList.First().Users.Count;

            Assert.Equal(0, miniLegueUserList.Count);
            Assert.Equal(0, usersCount);
        }

        [Fact]
        public void MiniLeguesByUserMethodReturnOnlyUserMiniLegues()
        {
            var miniLegueList = new List<MiniLigue>()
            {
                new MiniLigue
                {
                    Id = "aaaaa",
                    Name = "Milen",
                },
                new MiniLigue
                {
                    Id = "bbbbb",
                    Name = "georgi",
                },
            };

            var miniLegueUserList = new List<MiniLigueUser>()
            {
                new MiniLigueUser
                {
                    MiniLigueId = "aaaaa",
                    UserId = "abc",
                    MiniLigue = miniLegueList[0],
                },
                new MiniLigueUser
                {
                    MiniLigueId = "bbbbb",
                    UserId = "abc",
                    MiniLigue = miniLegueList[1],
                },
                new MiniLigueUser
                {
                    MiniLigueId = "aaaaa",
                    UserId = "def",
                    MiniLigue = miniLegueList[0],
                },
            };

            var miniLeagueRepo = new Mock<IDeletableEntityRepository<MiniLigue>>();

            var miniUserRepo = new Mock<IDeletableEntityRepository<MiniLigueUser>>();
            miniUserRepo.Setup(x => x.All()).Returns(miniLegueUserList.AsQueryable());

            var service = new MiniLeaguesService(miniLeagueRepo.Object, miniUserRepo.Object);

            var leagues = service.MiniLiguesByUser("abc");

            var miniLegueId = leagues.Select(x => x.Id).FirstOrDefault();
            var miniLegueName = leagues.Select(x => x.Name).FirstOrDefault();

            Assert.Equal(2, leagues.Count());
            Assert.Equal("bbbbb", miniLegueId);
            Assert.Equal("georgi", miniLegueName);

        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);

            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
            {
                hashedInputStringBuilder.Append(b.ToString("X2"));
            }

            return hashedInputStringBuilder.ToString();
        }
    }
}
