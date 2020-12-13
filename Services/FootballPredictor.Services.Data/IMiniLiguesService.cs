namespace FootballPredictor.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FootballPredictor.Web.ViewModels.MiniLigues;

    public interface IMiniLiguesService
    {
        public IEnumerable<AllVIewModel> All();

        Task CreateAsync(CreateInputModel model, string userId);

        DashboardViewModel Dashboard(string id);

        bool IsAMember(string miniLigueId, string userId);

        bool IsCorrectPassword(string miniLigueId, string password);

        string MiniLigueName(string id);

        Task Join(JoinViewModel model, string userId);

        Task RemoveAsync(string userId, string creatorId);

        IEnumerable<AllVIewModel> MiniLiguesByUser(string userId);
    }
}
