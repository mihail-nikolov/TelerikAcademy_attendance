using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Models
{
    public class User : IdentityUser
    {
        private ICollection<Rate> rates;
        private ICollection<Comment> comments;

        public User()
        {
            this.Rates = new HashSet<Rate>();
            this.Comments = new HashSet<Comment>();
        }

        public virtual ICollection<Rate> Rates
        {
            get { return this.rates; }
            set { this.rates = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
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
