namespace Teleimot.Web.Api.Models.Users
{
    using Data.Models;
    using Infrastructure;
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class UserRateRequestModel:IMapFrom<Rating>
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [Range(RatingConstants.MinRating, RatingConstants.MaxRating)]
        public int Value { get; set; }
    }
}