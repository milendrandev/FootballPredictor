using FootballPredictor.Web.ViewModels.Matches;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballPredictor.Services.Data
{
    public interface IMatchesService
    {
        ICollection<AllMatchesForTheWeekViewModel> GetAll();
    }
}
