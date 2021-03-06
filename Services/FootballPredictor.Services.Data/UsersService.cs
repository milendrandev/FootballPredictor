﻿namespace FootballPredictor.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FootballPredictor.Common;
    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Web.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Match> matchRepository;
        private readonly IDeletableEntityRepository<Prediction> predictionRepository;
        private readonly IDeletableEntityRepository<GameweekUser> gameweekUserRepository;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<Match> matchRepository,
            IDeletableEntityRepository<Prediction> predictionRepository,
            IDeletableEntityRepository<GameweekUser> gameweekUserRepository)
        {
            this.userRepository = userRepository;
            this.matchRepository = matchRepository;
            this.predictionRepository = predictionRepository;
            this.gameweekUserRepository = gameweekUserRepository;
        }

        public async Task CreateUserInGameweek(int gameweekId, string userId)
        {
            var user = this.gameweekUserRepository.All().Where(g => g.GameweekId == gameweekId && g.UserId == userId).FirstOrDefault();

            if (user != null)
            {
                return;
            }

            await this.gameweekUserRepository.AddAsync(new GameweekUser
            {
                GameweekId = gameweekId,
                UserId = userId,
            });

            await this.gameweekUserRepository.SaveChangesAsync();
        }

        public IEnumerable<RankingsViewModel> Rankings()
        {
            return this.userRepository.All().Select(u => new RankingsViewModel
            {
                Id = u.Id,
                Username = u.UserName,
                UserPoints = u.UserPoints,
            })
                 .OrderByDescending(u => u.UserPoints)
                 .ToList();
        }

        public UserGameweekPointsViewModel UserGameweeksPoints(string userId)
        {
            var user = this.userRepository.All().Where(u => u.Id.Equals(userId)).Select(u => new UserGameweekPointsViewModel
            {
                Username = u.UserName,
                GameweekPoints = u.UserGameweeks.Select(g => new GameweekPointsViewModel
                {
                    Id = g.GameweekId,
                    GameweekPoints = g.UserPoints,
                }).ToList(),
                TotalPoints = u.UserPoints,
            }).FirstOrDefault();

            return user;
        }

        public void AddPointsToUser()
        {
            var users = this.userRepository.All().ToList();

            var matches = this.matchRepository.All().Where(m => m.GameweekId == GlobalConstants.CurrentWeek).ToList();

            foreach (var user in users)
            {
                var predictions = this.predictionRepository.All().Where(p => p.UserId.Equals(user.Id)).ToList();
                var gameweekUser = this.gameweekUserRepository.All().Where(g => g.GameweekId == GlobalConstants.CurrentWeek && g.UserId == user.Id).FirstOrDefault();

                if (gameweekUser == null || predictions.Count == 0)
                {
                    continue;
                }

                foreach (var prediction in predictions)
                {
                    var match = matches.Where(m => m.Id == prediction.MatchId).FirstOrDefault();

                    if (match == null)
                    {
                        continue;
                    }

                    if (match.ResultType == prediction.Bet)
                    {
                        user.UserPoints += 10;
                        gameweekUser.UserPoints += 10;

                        if (match.HomeGoals == prediction.HomeTeamGoals && match.AwayGoals == prediction.AwayTeamGoals)
                        {
                            user.UserPoints += 40;
                            gameweekUser.UserPoints += 40;
                        }
                        else if (match.HomeGoals == prediction.HomeTeamGoals)
                        {
                            user.UserPoints += 10;
                            gameweekUser.UserPoints += 10;
                        }
                        else if (match.AwayGoals == prediction.AwayTeamGoals)
                        {
                            user.UserPoints += 10;
                            gameweekUser.UserPoints += 10;
                        }
                    }
                }

                this.userRepository.Update(user);
                this.gameweekUserRepository.Update(gameweekUser);
            }

            this.userRepository.SaveChanges();
        }
    }
}
