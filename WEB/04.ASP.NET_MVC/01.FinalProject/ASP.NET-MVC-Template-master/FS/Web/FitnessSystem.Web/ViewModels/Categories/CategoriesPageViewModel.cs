namespace FitnessSystem.Web.ViewModels.Categories
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CategoriesPageViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual int Exercises { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Category, CategoriesPageViewModel>()
              .ForMember(x => x.Exercises, opt => opt.MapFrom(x => x.Exercises.Count));
        }
    }
}
