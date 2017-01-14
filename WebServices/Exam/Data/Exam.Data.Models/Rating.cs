namespace Exam.Data.Models
{
    using Common.Constants;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Rate
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        //[Required]
        [Range(RealEstateConstants.RatingMin, RealEstateConstants.RatingMax)]
        public double Rating { get; set; }
    }
}
