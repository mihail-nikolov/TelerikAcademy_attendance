using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class LetiSpaghetti : Driver
    {
        private const string name = "Leti Spaghetti";

        public LetiSpaghetti() 
            : base(LetiSpaghetti.name, GenderType.Female)
        {
        }
    }
}
