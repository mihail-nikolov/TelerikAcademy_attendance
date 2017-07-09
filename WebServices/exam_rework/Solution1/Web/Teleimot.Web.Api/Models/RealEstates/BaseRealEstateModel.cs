namespace Teleimot.Web.Api.Models.RealEstates
{
    using System.ComponentModel.DataAnnotations;
    using Teleimot.Common;

    public class BaseRealEstateModel
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(RealEstateConstants.TitleMaxLength, ErrorMessage = "max len:{1}, min len: {2}.", MinimumLength = RealEstateConstants.TitleMinLength)]
        public string Title { get; set; }

        public int? SellingPrice { get; set; }

        public int? RentingPrice { get; set; }
    }
}