using System.Collections.Generic;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Extensions;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface IDriver : IIdentifiable<int> // added IIdentifiable to be able to use GetById
    {
        string Name { get; }
        GenderType Gender { get; }
        IMotorVehicle ActiveVehicle { get; }
        IEnumerable<IMotorVehicle> Vehicles { get; }
        void AddVehicle(IMotorVehicle vehicle);
        void SetActiveVehicle(IMotorVehicle vehicle);
        bool RemoveVehicle(IMotorVehicle vehicle);
    }
}
