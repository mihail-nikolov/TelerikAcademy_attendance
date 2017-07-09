namespace Teleimot.Data.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User: IdentityUser
    {
        private ICollection<Comment> comments;
        private ICollection<Rating> ratings;
        private ICollection<RealEstate> realEstates;

        public User()
        {
            this.comments = new HashSet<Comment>();
            this.ratings = new HashSet<Rating>();
            this.realEstates = new HashSet<RealEstate>(); ;
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public virtual ICollection<Rating> Ratings
        {
            get
            {
                return this.ratings;
            }
            set
            {
                this.ratings = value;
            }
        }

        public virtual ICollection<RealEstate> RealEstates
        {
            get
            {
                return this.realEstates;
            }
            set
            {
                this.realEstates = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}