namespace FootballPredictor.Services.Data
{
    using FootballPredictor.Web.ViewModels.Players;
    using FootballPredictor.Web.ViewModels.Teams;

   public interface ITeamsService
    {
        TeamDetailViewModel TeamDetails(int id);

        ListOfPlayerViewModel GetSquad(int id);
    }
}
