namespace FootballPredictor.Data.Models.ModelsDto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PlayerDtoSeeder
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string ShortName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string LongName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        public string Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public string HeightCm { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(3)]
        public string WeightKg { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Nationality { get; set; }

        [Required]
        public string ClubName { get; set; }

        [Required]
        public string LeagueName { get; set; }

        [Range(1, 99)]
        public int TeamNumber { get; set; }
    }
}
