namespace FitnessSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Exercises = new HashSet<Exercise>();
            this.Comments = new HashSet<Comment>();
        }

        [Index]
        public bool IsDeleted { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        [Required]
        public virtual string NickName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
