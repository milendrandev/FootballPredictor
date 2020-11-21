using FootballPredictor.Web.ViewModels.Predictions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballPredictor.Services.Data
{
    public interface IPredictionsService
    {
        Task CreateAsync(int id, int homeGoals, int awayGoals, string description, string userId);
    }
}
