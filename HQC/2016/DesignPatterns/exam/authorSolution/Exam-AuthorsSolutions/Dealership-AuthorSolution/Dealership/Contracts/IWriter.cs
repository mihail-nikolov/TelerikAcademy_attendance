namespace Dealership.Contracts
{
    public interface IWriter
    {
        void Write(string toWrite);
        void WriteLine(string toWrite);
    }
}
