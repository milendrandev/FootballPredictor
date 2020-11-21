using FootballPredictor.Web.ViewModels.Matches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballPredictor.Services.Data
{
    public interface IMatchesService
    {
        ICollection<AllMatchesForTheWeekViewModel> GetAll();

        void Simulate();
    }
}
