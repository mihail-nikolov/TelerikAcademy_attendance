using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Models
{
    public class Director
    {
        private ICollection<Movie> movies;

        public Director()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        public int Age { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }
    }
}