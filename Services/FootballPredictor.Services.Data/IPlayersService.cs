namespace FootballPredictor.Services.Data
{
    using FootballPredictor.Web.ViewModels.Players;

    public interface IPlayersService
    {
        ListOfRankigsViewModel Rankings();
    }
}
