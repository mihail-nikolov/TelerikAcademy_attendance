namespace FitnessSystem.Web.ViewModels.Feedbacks
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class FeedbackCreateViewModel : IMapFrom<Feedback>
    {
        [Required]
        [StringLength(15, ErrorMessage = "max len:{1}, min len: {2}.", MinimumLength = 3)]
        public string Title { get; set; }

        //[UIHint("tinymce_full")]
        //[AllowHtml]
        [DataType(DataType.MultilineText)]
        [Required]
        [MinLength(5, ErrorMessage = " min len: {1}")]
        public string Content { get; set; }
    }
}
