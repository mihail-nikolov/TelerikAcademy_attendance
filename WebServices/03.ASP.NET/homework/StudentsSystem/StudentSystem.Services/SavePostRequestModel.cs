namespace StudentSystem.Services
{
    using CodeFirst.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SavePostRequestModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CategoryId { get; set; }
    }
}