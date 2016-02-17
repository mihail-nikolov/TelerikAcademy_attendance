namespace Movies.Data
{
    using System.Data.Entity;
    using Models;

    public class MoviesDbContext: DbContext
    {
        public static MoviesDbContext Create()
        {
            return new MoviesDbContext();
        }

        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<Director> Directors { get; set; }

        public IDbSet<Actor> Actors { get; set; }

        public IDbSet<Actress> Actresses { get; set; }

        public IDbSet<Studio> Studios { get; set; }
    }
}