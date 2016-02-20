﻿namespace FitnessSystem.Web.ViewModels.Categories
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Data.Models;
    using Infrastructure.Mapping;

    public class ManageCategoriesSimpleViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(10, ErrorMessage = "max len:{1}, min len: {2}.", MinimumLength = 3)]
        public string Name { get; set; }

        //public DateTime CreatedOn { get; set; }

        //public DateTime? ModifiedOn { get; set; }

        public bool IsVisible { get; set; }
    }
}