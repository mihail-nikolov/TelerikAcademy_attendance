namespace FitnessSystem.Web.ViewModels.Exercises
{
    using Comments;

    public class ExerciseAndNewCommentViewModel
    {
        public ExerciseFullViewModel Exercise { get; set; }

        public CommentViewModel NewComment { get; set; }
    }
}