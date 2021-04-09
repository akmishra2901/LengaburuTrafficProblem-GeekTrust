using System;
using System.Collections.Generic;
using System.Text;
using geektrust.Vehicle;
using geektrust.Enums;

namespace geektrust.Base
{
    public abstract class VehicleBase<T>
    {
        public abstract string Name { get; }
        public abstract double Speed { get; }
        public abstract double TimeToCrossCrater { get; }
        public abstract VehicleTypeEnum VehicleType { get; }
        public abstract bool CanTravel(WeatherEnum weather);
    }
}
