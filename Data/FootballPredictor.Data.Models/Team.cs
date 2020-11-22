namespace FootballPredictor.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using FootballPredictor.Data.Common.Models;

    public class Team : BaseDeletableModel<int>
    {
        public Team()
        {
            this.Matches = new HashSet<Match>();
            this.Players = new HashSet<Player>();

            this.Points = 0;
            this.Wins = 0;
            this.Draws = 0;
            this.Looses = 0;
            this.Points = 0;
            this.ScoredGoals = 0;
            this.ConcededGoals = 0;
            this.MatchesPlayed = 0;
        }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public string Code { get; set; }

        [Required]
        [MaxLength(20)]
        public string Country { get; set; }

        public League League { get; set; }

        [ForeignKey(nameof(League))]
        [Required]
        public int LeagueId { get; set; }

        public int Points { get; set; }

        public int ScoredGoals { get; set; }

        public int ConcededGoals { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Looses { get; set; }

        public virtual ICollection<Match> Matches { get; set; }

        public int MatchesPlayed { get; set; }

        public virtual ICollection<Player> Players { get; set; }

    }
}
