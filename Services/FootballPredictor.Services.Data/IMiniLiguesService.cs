namespace FootballPredictor.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FootballPredictor.Web.ViewModels.MiniLigues;

    public interface IMiniLiguesService
    {
        public IEnumerable<AllVIewModel> All();

        Task CreateAsync( CreateInputModel model, string userId);

        DashboardViewModel Dashboard(string id);

        bool IsAMember(string miniLigueId, string userId);
    }
}
