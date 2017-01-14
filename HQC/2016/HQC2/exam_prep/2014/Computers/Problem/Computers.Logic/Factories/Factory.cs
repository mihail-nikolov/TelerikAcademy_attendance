namespace Computers.Logic.Factories
{
    using Computers.Logic.ComputerTypes;
    using Computers.Logic.Factories.Contracts;

    public abstract class Factory : IFactory
    {
        public Factory()
        {
        }

        public abstract Laptop CreateLaptop();

        public abstract PersonalComputer CreatePersonalComputer();

        public abstract Server CreateServer();
    }
}
