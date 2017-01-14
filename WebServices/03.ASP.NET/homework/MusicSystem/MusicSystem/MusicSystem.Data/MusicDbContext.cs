using MusicSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSystem.Data
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext() 
            : base("MusicSystemDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        public virtual IDbSet<Album> Albums { get; set; }
        public virtual IDbSet<Artist> Artists { get; set; }
        public virtual IDbSet<Song> Songs { get; set; }
    }
}
