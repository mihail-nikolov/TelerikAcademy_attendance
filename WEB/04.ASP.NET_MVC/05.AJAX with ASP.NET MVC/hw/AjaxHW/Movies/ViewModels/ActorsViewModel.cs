using Movies.Data;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.ViewModels
{
    public class ActorsViewModel
    {
        public static IEnumerable<Actor> Actors
        {
            get
            {
                var mvd = new MoviesDbContext();
                return mvd.Actors.ToList();
            }
        }
    }
}