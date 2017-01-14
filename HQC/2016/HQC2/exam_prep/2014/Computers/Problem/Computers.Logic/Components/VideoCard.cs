namespace Computers.Logic.Components
{
    using Contracts;

    public abstract class VideoCard : IVideoCard
    {
        public VideoCard()
        {
        }

        public abstract void Draw(string text);
    }
}
