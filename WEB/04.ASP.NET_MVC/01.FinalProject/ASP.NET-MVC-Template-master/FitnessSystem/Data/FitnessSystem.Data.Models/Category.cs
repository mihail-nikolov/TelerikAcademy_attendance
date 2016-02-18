namespace FitnessSystem.Data.Models
{
    using System.Collections.Generic;

    using FitnessSystem.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Category : BaseModel<int>
    {
        public Category()
        {
            //this.Jokes = new HashSet<Joke>();
        }

        [Required]
        [StringLength(10, ErrorMessage = "max len:{0}, min len: {2}.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public bool IsVisible { get; set; }

        //public virtual ICollection<Joke> Jokes { get; set; }
    }
}
