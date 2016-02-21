namespace FitnessSystem.Web.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ManageExerciseViewModel : IMapFrom<Exercise>, IMapTo<Exercise>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "min len: {1}")]
        public string Title { get; set; }

        [UIHint("CategoryDropDownList")]
        public string Category { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Exercise, ManageExerciseViewModel>()
               .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
