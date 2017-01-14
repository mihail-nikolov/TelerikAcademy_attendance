namespace Computers.Logic.Components.Contracts
{
    public interface ICPU
    {
        byte NumberOfCores { get; set; }

        string SquareNumber(int data);

        int GetRandomNumber(int min, int max);
    }
}
