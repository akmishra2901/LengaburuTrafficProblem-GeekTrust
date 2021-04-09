using System;
using System.Collections.Generic;
using System.Text;
using geektrust.Enums;

namespace geektrust.Class
{
    interface IOrbit
    {
        double GetTravelDurationOnOrbit(IWeather weather, VehicleTypeEnum vehicleTypeEnum);
    }
}
