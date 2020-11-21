using System.Collections.Generic;

namespace FootballPredictor.Data.Models.ModelsDto.Users
{
    public class UserAddPointsDto
    {
        public string Id { get; set; }

        public int Points { get; set; }

        public ICollection<UserPredictionsDto> Predictions { get; set; }
    }
}
