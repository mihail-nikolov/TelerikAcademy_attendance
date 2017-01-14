namespace Exam.Data.Models
{
    using Common.Constants;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class RealEstate
    {
        private ICollection<Comment> comments;

        public RealEstate()
        {
            this.Comments = new HashSet<Comment>();
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(RealEstateConstants.TitleMinLength)]
        [MaxLength(RealEstateConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(RealEstateConstants.DescriptionMinLength)]
        [MaxLength(RealEstateConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        public DateTime CreatedOn { get; set; }

        public RealEstateType Type { get; set; }

        [Range(RealEstateConstants.ConstructionMinYear, RealEstateConstants.ConstructionMaxYear)]
        public int ConstructionYear { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public int SellingPrice { get; set; }

        public int RentingPrice { get; set; }

        public string UserId { get; set; }
    }
}
