namespace FootballPredictor.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FootballPredictor.Data.Common.Models;

    public class Player : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(50)]
        public string ShortName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LongName { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int HeightCm { get; set; }

        public int WeightKg { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nationality { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }

        public Team Team { get; set; }

        [ForeignKey(nameof(League))]
        public int LeagueId { get; set; }

        public League League { get; set; }
    }
}
