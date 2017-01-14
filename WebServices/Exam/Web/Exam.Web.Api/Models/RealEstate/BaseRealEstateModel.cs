namespace Exam.Web.Api.Models.RealEstate
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class BaseRealEstateModel
    {
        [MinLength(RealEstateConstants.TitleMinLength)]
        [MaxLength(RealEstateConstants.TitleMaxLength)]
        public string Title { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public int SellingPrice { get; set; }

        public int RentingPrice { get; set; }     
    }
}
