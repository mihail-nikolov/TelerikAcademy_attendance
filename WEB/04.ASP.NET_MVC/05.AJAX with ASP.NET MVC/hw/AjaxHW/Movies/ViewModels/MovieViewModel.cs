namespace Movies.ViewModels
{
    using Models;
    using Infrastructure;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class MovieViewModel : IMapFrom<Movie>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public Actor LeadingMaleRole { get; set; }

        public Actress LeadingFemaleRole { get; set; }
        
        public Director Director { get; set; }
        
        public Studio Studio { get; set; }
    }
}