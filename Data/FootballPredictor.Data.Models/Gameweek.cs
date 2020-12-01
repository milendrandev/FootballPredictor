namespace FootballPredictor.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using FootballPredictor.Data.Common.Models;

    public class Gameweek : BaseDeletableModel<int>
    {
        public Gameweek()
        {
            this.Predictions = new HashSet<Prediction>();
            this.Matches = new HashSet<Match>();
            this.GameweekUsers = new HashSet<GameweekUser>();
        }

        public virtual ICollection<Prediction> Predictions { get; set; }

        public virtual ICollection<Match> Matches { get; set; }

        public virtual ICollection<GameweekUser> GameweekUsers { get; set; }
    }
}
