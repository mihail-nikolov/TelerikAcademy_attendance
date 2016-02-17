namespace FitnessSystem.Web.ViewModels.Home
{
    using FitnessSystem.Data.Models;
    using FitnessSystem.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
