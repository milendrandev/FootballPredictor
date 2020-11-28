using System;

namespace FootballPredictor.Web.ViewModels.Players
{
    public class PlayerViewModel
    {
        public string ShortName { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int HeightCm { get; set; }

        public int WeightKg { get; set; }

        public string Nationality { get; set; }

        public int SquadNumber { get; set; }
    }
}
