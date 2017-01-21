namespace FitnessSystem.Web.Areas.Administration.ViewModels.Feedbacks
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class FeedbacksCheckViewModel : IMapFrom<Feedback>
    {
        [Required]
        [StringLength(15, ErrorMessage = "max len:{1}, min len{2}.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = " min len: {1}")]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
