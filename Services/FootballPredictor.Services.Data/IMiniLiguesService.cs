namespace FootballPredictor.Services.Data
{
    using System.Threading.Tasks;

    using FootballPredictor.Web.ViewModels.MiniLigues;

    public interface IMiniLiguesService
    {
        Task CreateAsync( CreateInputModel model);
    }
}
