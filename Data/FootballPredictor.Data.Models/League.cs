namespace FootballPredictor.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FootballPredictor.Data.Common.Models;

    public class League : BaseDeletableModel<int>
    {
        public League()
        {
            this.Teams = new HashSet<Team>();
            this.Matches = new HashSet<Match>();
        }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Country { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
