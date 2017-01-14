using System.Collections.Generic;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Utils;
using FastAndFurious.ConsoleApplication.Contracts;

namespace FastAndFurious.ConsoleApplication.Models.Drivers.Abstract
{
    public abstract class Driver : IDriver
    {
        private readonly int id;
        private IList<IMotorVehicle> vehicles;

        public Driver(string name, GenderType gender)
        {
            this.id = DataGenerator.GenerateId();
            this.vehicles = new List<IMotorVehicle>();
            this.Name = name;
        }

        public IMotorVehicle ActiveVehicle { get; protected set; }

        public GenderType Gender { get; protected set; }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Name { get; protected set; }

        public IEnumerable<IMotorVehicle> Vehicles
        {
            get
            {
                return new List<IMotorVehicle>(this.vehicles);
            }
        }

        public void AddVehicle(IMotorVehicle vehicle)
        {
            this.vehicles.Add(vehicle);
        }
        public bool RemoveVehicle(IMotorVehicle vehicle)
        {
            if (this.vehicles.Contains(vehicle))
            {
                this.vehicles.Remove(vehicle);
                return true;
            }
            return false;
        }

        public void SetActiveVehicle(IMotorVehicle vehicle)
        {
            this.ActiveVehicle = vehicle;
        }
    }
}
