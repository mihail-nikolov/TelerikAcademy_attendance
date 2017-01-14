namespace Computers.Logic.Factories
{
    using System.Collections.Generic;
    using Components;
    using Computers.Logic.ComputerTypes;
    using Contracts;

    public class HPFactory : Factory, IFactory
    {
        private const int LaptopRam = 4;
        private const int LaptopCPUCores = 2;
        private const int LaptopHDDCapacity = 500;

        private const int PersonalComputerRam = 2;
        private const int PersonalComputerCPUCores = 2;
        private const int PersonalComputerHDDCapacity = 500;

        private const int ServerRam = 64;
        private const int ServerCPUCores = 8;
        private const int ServerHDDCapacity = 2000;

        public HPFactory() : base()
        {
        }

        public override Laptop CreateLaptop()
        {
            var ram = new RAM(LaptopRam);
            var videoCard = new ColorfulVideoCard();
            var motherBoard = new MotherBoard(ram, videoCard);

            var cpu = new CPU64(LaptopCPUCores);
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

            var cpu = new CPU32(PersonalComputerCPUCores);
            var hardDrive = new HDD(PersonalComputerHDDCapacity);

            var pc = new PersonalComputer(motherBoard, cpu, hardDrive);

            return pc;
        }

        public override Server CreateServer()
        {
            var ram = new RAM(ServerRam);
            var videoCard = new MonochromeVideoCard();
            var motherBoard = new MotherBoard(ram, videoCard);

            var cpu = new CPU32(ServerCPUCores);

            var hdds = new List<HDD> { new HDD(ServerHDDCapacity), new HDD(ServerHDDCapacity) };
            var hardDrive = new RaidArray(hdds);

            var server = new Server(motherBoard, cpu, hardDrive);

            return server;
        }
    }
}