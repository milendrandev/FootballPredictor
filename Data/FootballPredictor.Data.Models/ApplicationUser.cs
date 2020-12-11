// ReSharper disable VirtualMemberCallInConstructor
namespace FootballPredictor.Data.Models
{
    using System;
    using System.Collections.Generic;

    using FootballPredictor.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Predictions = new HashSet<Prediction>();
            this.UserGameweeks = new HashSet<GameweekUser>();
            this.MiniLigues = new HashSet<MiniLigueUser>();
        }

        public int UserPoints { get; set; }

        public virtual ICollection<Prediction> Predictions { get; set; }

        public virtual ICollection<GameweekUser> UserGameweeks { get; set; }

        public virtual ICollection<MiniLigueUser> MiniLigues { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
