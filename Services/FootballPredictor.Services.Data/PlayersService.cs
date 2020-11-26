namespace FootballPredictor.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Web.ViewModels.Players;

    public class PlayersService : IPlayersService
    {
        private readonly IDeletableEntityRepository<Player> playerRepository;

        public PlayersService(IDeletableEntityRepository<Player> playerRepository)
        {
            this.playerRepository = playerRepository;
        }
        //public ListOfPlayerViewModel GetSquad(int id)
        //{
        //    var players = this.playerRepository.All().Where(p=> p.TeamId == id)
        //        .Select(p=> new ListOfPlayerViewModel
        //        {
        //            Players = p.
        //        })
        //}
    }
}
