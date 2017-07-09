namespace Teleimot.Web.Api.Models.RealEstates
{
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Data.Models;
    using Infrastructure;

    public class CreateRealEstateRequestModel : BaseRealEstateModel, IMapFrom<RealEstate>
    {
        [Required]
        [StringLength(RealEstateConstants.DescriptionMaxLength, ErrorMessage = "max len:{1}, min len: {2}.", MinimumLength = RealEstateConstants.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Range(RealEstateConstants.ConstructionMinYear, uint.MaxValue)]
        public int ConstructionYear { get; set; }

        [Required]
        public string Contact { get; set; }

        public RealEstateType Type { get; set; }
    }
}