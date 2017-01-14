namespace Exam.Web.Api.Models.RealEstate
{
    using Data.Models;
    using Common.Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateRealEstateRequestModel:BaseRealEstateModel
    {
        [Required]
        [MinLength(RealEstateConstants.DescriptionMinLength)]
        [MaxLength(RealEstateConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }
        
        [Range(RealEstateConstants.ConstructionMinYear, RealEstateConstants.ConstructionMaxYear)]
        public int ConstructionYear { get; set; }

        public RealEstateType Type { get; set; }

        public string UserId { get; set; }

        [Required]
        public string Contact { get; set; }
    }
}