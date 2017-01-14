﻿using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class VinBenzin : Driver
    {
        private const string name = "Vin Benzin";

        public VinBenzin() 
            : base(VinBenzin.name, GenderType.Male)
        {
        }
    }
}
