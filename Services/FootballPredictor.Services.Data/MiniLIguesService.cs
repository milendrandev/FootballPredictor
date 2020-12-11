namespace FootballPredictor.Services.Data
{
    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Web.ViewModels.MiniLigues;
    using System.Threading.Tasks;

    public class MiniLIguesService : IMiniLiguesService
    {
        private readonly IDeletableEntityRepository<MiniLigue> miniLigueRepository;

        public MiniLIguesService(IDeletableEntityRepository<MiniLigue> miniLigueRepository)
        {
            this.miniLigueRepository = miniLigueRepository;
        }

        public async Task CreateAsync(CreateInputModel model)
        {
            var miniligue = new MiniLigue
            {
                Name = model.Name,
                MiniLigueType = model.MiniLigueType,
            };

            if (model.Password != null)
            {
                miniligue.Password = model.Password;
            }

            await this.miniLigueRepository.AddAsync(miniligue);
            await this.miniLigueRepository.SaveChangesAsync();
        }
    }
}
