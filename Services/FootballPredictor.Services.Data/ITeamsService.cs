namespace FootballPredictor.Services.Data
{
    using FootballPredictor.Web.ViewModels.Teams;

   public interface ITeamsService
    {
        TeamDetailViewModel TeamDetails(int teamId);
    }
}
