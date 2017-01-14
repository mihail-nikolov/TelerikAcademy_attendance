namespace Computers.Logic.Factories.Contracts
{
    using Computers.Logic.ComputerTypes;

    public interface IFactory
    {
        PersonalComputer CreatePersonalComputer();

        Laptop CreateLaptop();

        Server CreateServer();
    }
}
