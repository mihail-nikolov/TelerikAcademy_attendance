using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Exam.Common.Constants;

namespace Exam.Web.Api.Models.ClassesToMap
{
    public class CreateGameRequestModel : IValidatableObject
    {
        [Required]
        [MinLength(GameConstants.GuessNumberLength)]
        [MaxLength(GameConstants.GuessNumberLength)]
        public string Number { get; set; }

        [Required]
        [MaxLength(GameConstants.GameNameMaxLength)]
        public string Name { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var digits = this
                .Number
                .Where(char.IsDigit)
                .Distinct()
                .ToList();

            if (digits.Count() != GameConstants.GuessNumberLength)
            {
                yield return new ValidationResult("Number's digits must be distinct!");
            }
        }
    }
}