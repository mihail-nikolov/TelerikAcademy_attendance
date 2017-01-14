using CodeFirst.Data;
using MusicSystem.Data;
using MusicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicSystemServices.Controllers
{
    public class SongsController : ApiController
    {
        private readonly IRepository<Song> data;

        public SongsController()
        {
            this.data = new EfGenericRepository<Song>(new MusicDbContext());
        }


        public IHttpActionResult Get()
        {
            var songs = this.data.All().ToList();
            return this.Ok(songs);          
        }

        public IHttpActionResult Get(string Title)
        {
            if (string.IsNullOrEmpty(Title))
            {
                return this.BadRequest("Song name cannot be null or empty.");
            }
            var song = this.data.All()
                .FirstOrDefault(s => s.Title == Title);

            if (song == null)
            {
                return this.NotFound();
            }

            return this.Ok(song);
        }
    }
}
