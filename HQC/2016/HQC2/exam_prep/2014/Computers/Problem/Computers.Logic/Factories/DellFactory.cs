namespace Computers.Logic.Factories
{
    using System.Collections.Generic;
    using Components;
    using Computers.Logic.Factories.Contracts;
    using ComputerTypes;

    public class DellFactory : Factory, IFactory
    {
        private const int LaptopRam = 8;
        private const int LaptopCPUCores = 4;
        private const int LaptopHDDCapacity = 1000;

        private const int PersonalComputerRam = 8;
        private const int PersonalComputerCPUCores = 4;
        private const int PersonalComputerHDDCapacity = 1000;

        private const int ServerRam = 64;
        private const int ServerCPUCores = 8;
        private const int ServerHDDCapacity = 2000;

        public DellFactory() : base()
        {
        }

        public override Laptop CreateLaptop()
        {
            var ram = new RAM(LaptopRam);
            var videoCard = new ColorfulVideoCard();
            var motherBoard = new MotherBoard(ram, videoCard);

            var cpu = new CPU32(LaptopCPUCores);
            var hardDrive = new HDD(LaptopHDDCapacity);
            var battery = new LaptopBattery();

            var laptop = new Laptop(motherBoard, cpu, hardDrive, battery);

            return laptop;
        }

        public override PersonalComputer CreatePersonalComputer()
        {
            var ram = new RAM(PersonalComputerRam);
            var videoCard = new ColorfulVideoCard();
            var motherBoard = new MotherBoard(ram, videoCard);

            var cpu = new CPU64(PersonalComputerCPUCores);
            var hardDrive = new HDD(PersonalComputerHDDCapacity);

            var pc = new PersonalComputer(motherBoard, cpu, hardDrive);

            return pc;
        }

        public override Server CreateServer()
        {
            var ram = new RAM(ServerRam);
            var videoCard = new MonochromeVideoCard();
            var motherBoard = new MotherBoard(ram, videoCard);

            var cpu = new CPU64(ServerCPUCores);

            var hdds = new List<HDD> { new HDD(ServerHDDCapacity), new HDD(ServerHDDCapacity) };
            var hardDrive = new RaidArray(hdds);

            var server = new Server(motherBoard, cpu, hardDrive);

            return server;
        }
    }
}
