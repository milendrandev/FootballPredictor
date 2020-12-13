namespace FootballPredictor.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Web.ViewModels.MiniLigues;
    using FootballPredictor.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;

    public class MiniLIguesService : IMiniLiguesService
    {
        private readonly IDeletableEntityRepository<MiniLigue> miniLigueRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<MiniLigueUser> miniLigueUserRepository;

        public MiniLIguesService(
            IDeletableEntityRepository<MiniLigue> miniLigueRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<MiniLigueUser> miniLigueUserRepository)
        {
            this.miniLigueRepository = miniLigueRepository;
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.miniLigueUserRepository = miniLigueUserRepository;
        }

        public IEnumerable<AllVIewModel> All()
        {
            return this.miniLigueRepository.All().Select(x => new AllVIewModel
            {
                Id = x.Id,
                Name = x.Name,
            })
                .OrderBy(x => x.Name)
                .ToList();
        }

        public async Task CreateAsync(CreateInputModel model, string userId)
        {
            var miniLigue = new MiniLigue
            {
                Name = model.Name,
                Password = ComputeHash(model.Password),
                CreatorId = userId,
            };

            await this.AddUserToCreatorRole(userId);

            await this.miniLigueRepository.AddAsync(miniLigue);
            await this.miniLigueRepository.SaveChangesAsync();

            await this.CreateMiniLigueUser(miniLigue.Id, userId);
        }

        public DashboardViewModel Dashboard(string id)
        {
            var miniLigue = this.miniLigueRepository.All().Where(x => x.Id.Equals(id)).Select(m => new DashboardViewModel
            {
                Name = m.Name,
                CreatorId = m.CreatorId,
                Users = m.Users.Select(u => new RankingsViewModel
                {
                    Id = u.User.Id,
                    Username = u.User.UserName,
                    UserPoints = u.User.UserPoints,
                }).OrderByDescending(u => u.UserPoints),
            }).FirstOrDefault();

            return miniLigue;
        }

        public bool IsAMember(string miniLigueId, string userId)
        {
            var member = this.miniLigueUserRepository.All().Where(m => m.MiniLigueId.Equals(miniLigueId) && m.UserId.Equals(userId)).FirstOrDefault();

            if (member == null)
            {
                return false;
            }

            return true;
        }

        public bool IsCorrectPassword(string miniLigueId, string password)
        {
            var miniLigue = this.miniLigueRepository.All().FirstOrDefault(x => x.Id.Equals(miniLigueId));

            if (miniLigue.Password == ComputeHash(password))
            {
                return true;
            }

            return false;
        }

        public string MiniLigueName(string id)
        {
            return this.miniLigueRepository.All().Where(x => x.Id.Equals(id)).Select(x => x.Name).FirstOrDefault();
        }

        private async Task AddUserToCreatorRole(string userId)
        {
            var user = this.userRepository.All().FirstOrDefault(u => u.Id.Equals(userId));

            await this.userManager.AddToRoleAsync(user, "Creator");
        }

        public async Task Join(JoinViewModel model, string userId)
        {
            var memberToMiniLigue = new MiniLigueUser
            {
                MiniLigueId = model.Id,
                UserId = userId,
            };

            await this.miniLigueUserRepository.AddAsync(memberToMiniLigue);
            await this.miniLigueUserRepository.SaveChangesAsync();
        }

        public async Task RemoveAsync(string userId, string creatorId)
        {
            var miniLigue = this.miniLigueRepository.All().FirstOrDefault(x => x.CreatorId.Equals(creatorId));

            var miniLigueUser = this.miniLigueUserRepository.All().Where(m => m.MiniLigueId.Equals(miniLigue.Id) && m.UserId.Equals(userId)).FirstOrDefault();

            this.miniLigueUserRepository.Delete(miniLigueUser);
            await this.miniLigueUserRepository.SaveChangesAsync();
        }

        public IEnumerable<AllVIewModel> MiniLiguesByUser(string userId)
        {
            var miniLigues = this.miniLigueUserRepository.All().Where(u => u.UserId.Equals(userId)).Select(m => new AllVIewModel
            {
                Id = m.MiniLigueId,
                Name = m.MiniLigue.Name,
            })
                .OrderBy(m => m.Name)
                .ToList();

            return miniLigues;
        }

        private async Task CreateMiniLigueUser(string miniLigueId, string userId)
        {
            var miniLigueUser = new MiniLigueUser
            {
                MiniLigueId = miniLigueId,
                UserId = userId,
            };

            await this.miniLigueUserRepository.AddAsync(miniLigueUser);
            await this.miniLigueUserRepository.SaveChangesAsync();
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
