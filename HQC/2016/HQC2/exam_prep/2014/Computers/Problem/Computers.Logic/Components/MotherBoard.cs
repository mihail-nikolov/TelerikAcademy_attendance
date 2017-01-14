namespace Computers.Logic.Components
{
    using Computers.Logic.Components.Contracts;

    public class MotherBoard : IMotherboard
    {
        private readonly RAM ram;
        private readonly IVideoCard videoCard;

        public MotherBoard(RAM ram, IVideoCard videoCard)
        {
            this.ram = ram;
            this.videoCard = videoCard;
        }

        public void DrawOnVideoCard(string data)
        {
            this.videoCard.Draw(data);
        }

        public int LoadRamValue()
        {
            int ramValue = this.ram.LoadValue();
            return ramValue;
        }

        public void SaveRamValue(int value)
        {
            this.ram.SaveValue(value);
        }
    }
}
