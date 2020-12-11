namespace FootballPredictor.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FootballPredictor.Data.Common.Models;
    using FootballPredictor.Data.Models.Enums;

    public class MiniLigue : BaseDeletableModel<string>
    {
        public MiniLigue()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Users = new HashSet<MiniLigueUser>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public MiniLigueType MiniLigueType { get; set; }

        public string Password { get; set; }

        public virtual ICollection<MiniLigueUser> Users { get; set; }
    }
}
