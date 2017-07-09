namespace Teleimot.Data.Models
{
    using BaseModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Teleimot.Common;

    public class RealEstate : BaseModel<int>
    {
        private ICollection<Comment> comments;

        public RealEstate()
        {
            this.comments = new HashSet<Comment>();
        }

        [Required]
        [StringLength(RealEstateConstants.TitleMaxLength, ErrorMessage = "max len:{1}, min len: {2}.", MinimumLength = RealEstateConstants.TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(RealEstateConstants.DescriptionMaxLength, ErrorMessage = "max len:{1}, min len: {2}.", MinimumLength = RealEstateConstants.DescriptionMinLength)]
        public string Description { get; set; }

        public RealEstateType Type { get; set; }

        [Range(RealEstateConstants.ConstructionMinYear, uint.MaxValue)]
        public int ConstructionYear { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        public bool ForRent { get; set; }

        public bool ForSale { set; get; }

        public int SellingPrice { get; set; }

        public int RentingPrice { set; get; }

        //[ForeignKey("UserId")]
        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
    }
}
