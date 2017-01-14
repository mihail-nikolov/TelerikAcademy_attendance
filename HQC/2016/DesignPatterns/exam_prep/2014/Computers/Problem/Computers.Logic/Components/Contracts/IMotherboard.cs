namespace Computers.Logic.Components.Contracts
{
    public interface IMotherboard
    {
        int LoadRamValue();

        void SaveRamValue(int value);

        void DrawOnVideoCard(string data);
    }
}
