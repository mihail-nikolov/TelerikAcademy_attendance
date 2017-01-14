using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Extensions;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface ITunningPart : IAccelerateable, ITopSpeed, IWeightable, IValuable, IIdentifiable<int> // added IIdentifiable to be able to use GetById
    {
        TunningGradeType GradeType { get; }
    }
}
